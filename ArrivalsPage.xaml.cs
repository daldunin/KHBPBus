using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace KHBPbus
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ArrivalPage : Page
    {

        public ArrivalPage()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DeparturePage));
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

                foreach (Shuttle departure in Schedule.Arrivals)
                {
                    if (departure.Direction == "To KHBP" && departure.BusStop == busStop.Content.ToString())
                    {
                        if (departure.isActiveOnDay(day.Content.ToString()))
                            found.Add(departure);
                    }
                }
            }
            return found;
        }

        private void ShowFoundShuttles(List<Shuttle> arrivalsToShow)
        {
            ArrivalsListView.Items.Clear();
            IEnumerable<Shuttle> sortedArrivals =
                from arrival in arrivalsToShow
                orderby arrival.Time // "ascending" is default
                select arrival;

            //departuresToShow.OrderBy(shuttle => shuttle);
            foreach (Shuttle arrival in sortedArrivals)
            {
                ArrivalsListView.Items.Add(arrival.Time.ToString(@"hh\:mm"));
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
            JSONTools.ListOfArrivals = Schedule.Arrivals;
            JSONTools.FileName = Schedule.arrivalsFileName;
            try
            {
                await JSONTools.deserializeJsonAsync();
            }
            catch
            {
                var dialog = new MessageDialog("No Schedule found.");
                await dialog.ShowAsync();
            }
            Schedule.Arrivals = JSONTools.ListOfArrivals;

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
            // If you need the clicked element:
            // Item whichOne = senderElement.DataContext as Item;
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
                    if (day.Content.ToString() == "Today" || day.Content.ToString() == DateTime.Now.DayOfWeek.ToString())
                    {
                        for (int i = 0; i < ArrivalsListView.Items.Count; i++)
                     //   foreach (ListViewItem item in ArrivalsListView.Items)
                        {
                            ListViewItem item = ArrivalsListView.Items[i] as ListViewItem;
                            TimeSpan itemTime = TimeSpan.Parse(item.Content.ToString());
                            if (DateTime.Now.TimeOfDay > itemTime)
                            {
                                // light grey
                                Color outdatedColor = Color.FromArgb(255, 150, 150, 150);
                                SolidColorBrush brush = new SolidColorBrush(outdatedColor);
                                //listItem.Background = brush;
                                item.Foreground = brush;
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