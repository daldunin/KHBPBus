using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.Data.Xml.Dom;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace KHBPbus
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class DeparturePage : Page
    {
        public DeparturePage()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddShuttle));
        }

        private List<Shuttle> SearchForShuttles()
        {
            List<Shuttle> found = new List<Shuttle>();
            if (BusStopComboBox != null && DayComboBox != null)
            {
                var day = (DayComboBox as ComboBox).SelectedValue as ComboBoxItem;
                var busStop = (BusStopComboBox as ComboBox).SelectedValue as ComboBoxItem;

                foreach (Shuttle departure in Schedule.Departures)
                    {
                        if (departure.Direction == "From KHBP" && departure.BusStop == busStop.Content.ToString())
                        {
                            if (departure.isActiveOnDay(day.Content.ToString()))
                                found.Add(departure);
                        }
                    }
            }
            return found;
        }

        private void ShowFoundShuttles(List<Shuttle> departuresToShow)
        {
            DeparturesListView.Items.Clear();
            IEnumerable<Shuttle> sortedDepartures =
                from departure in departuresToShow
                orderby departure.Time // "ascending" is default
                select departure;

            //departuresToShow.OrderBy(shuttle => shuttle);
            foreach (Shuttle departure in sortedDepartures)
            {
                //DeparturesListView.Items.Add(departure.Time.ToString(@"hh\:mm"));
                
                
                ListViewItem listItem = new ListViewItem();
                listItem.Content = departure.Time.ToString(@"hh\:mm");
                DeparturesListView.Items.Add(listItem);
                
            }

            markOutdatedShuttles();
        }

        private void DayComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowFoundShuttles(SearchForShuttles());
        }

        private void BusStopComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowFoundShuttles(SearchForShuttles());
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            JSONTools.ListOfArrivals = Schedule.Departures;
            JSONTools.FileName = Schedule.departuresFileName;
            try
            {
                await JSONTools.deserializeJsonAsync();
            }
            catch
            {
                var dialog = new MessageDialog("No Schedule found.");
                await dialog.ShowAsync();
            }
            Schedule.Departures = JSONTools.ListOfArrivals;

            ShowFoundShuttles(SearchForShuttles());
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EditShuttle));
        }

        private async void RemoveClick(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Are you sure you want to remove this Shuttle from your Schedule?");
            dialog.Commands.Add(new UICommand(
                "Yes",
                new UICommandInvokedHandler(this.CommandInvokedHandler)));
            dialog.Commands.Add(new UICommand(
                "No",
                new UICommandInvokedHandler(this.CommandInvokedHandler)));

            dialog.DefaultCommandIndex = 0;

            dialog.CancelCommandIndex = 1;

            await dialog.ShowAsync();
        }

        private void NotifyClick(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem menuItem = sender as MenuFlyoutItem;
            string departureTime = menuItem.DataContext.ToString();
            TimeSpan departureTimeSpan = TimeSpan.Parse(departureTime);
            TimeSpan notificationTimeSpan = departureTimeSpan.Subtract(TimeSpan.FromMinutes(15));

            string xml = @"<toast>
                    <visual>
                    <binding template=""ToastGeneric"">
                        <text>Shuttle leaves in 15 minutes!</text>
                        <text>Shuttle leaves at " + departureTime + @" </text>
                    </binding>
                    </visual>
                </toast>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            ScheduledToastNotification toast = 
                new ScheduledToastNotification(doc, DateTimeOffset.Parse(notificationTimeSpan.ToString()));
            ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            if (command.Label == "Yes")
            {

            }
            else
            {

            }
        }

        private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
        }



        private void markOutdatedShuttles()
        {
            try
            {
                if (DayComboBox != null)
                {
                    var day = (DayComboBox as ComboBox).SelectedValue as ComboBoxItem;
                    if (day.Content.ToString() == "Today" || day.Content.ToString() == DateTime.UtcNow.DayOfWeek.ToString())
                    {
                        foreach (var item in DeparturesListView.Items)
                        {
                            ListViewItem listItem = (ListViewItem)item;
                            TimeSpan itemTime = TimeSpan.Parse(listItem.Content.ToString());
                            if (DateTime.UtcNow.TimeOfDay > itemTime)
                            {
                                // light grey
                                Color outdatedColor = Color.FromArgb(255, 150, 150, 150);
                                SolidColorBrush brush = new SolidColorBrush(outdatedColor);
                                //listItem.Background = brush;
                                listItem.Foreground = brush;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}
