using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace KHBPbus
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class AddShuttle : Page
    {

        public AddShuttle()
        {
            this.InitializeComponent();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            List<string> days = new List<string>();
            MessageDialog dialog;
            
            if (MondayCheckBox.IsChecked == true)
                days.Add(MondayCheckBox.Content.ToString());
            if (TuesdayCheckBox.IsChecked == true)
                days.Add(TuesdayCheckBox.Content.ToString());
            if (WednesdeyCheckBox.IsChecked == true)
                days.Add(WednesdeyCheckBox.Content.ToString());
            if (ThursdayCheckBox.IsChecked == true)
                days.Add(ThursdayCheckBox.Content.ToString());
            if (FridayCheckBox.IsChecked == true)
                days.Add(FridayCheckBox.Content.ToString());
            if (SaturdayCheckBox.IsChecked == true)
                days.Add(SaturdayCheckBox.Content.ToString());
            if (SundayCheckBox.IsChecked == true)
                days.Add(SundayCheckBox.Content.ToString());

            if (DirectionComboBox.SelectionBoxItem.ToString() == "To KHPB")
                foreach (Shuttle sh in Schedule.Arrivals)
                {
                    if (Enumerable.SequenceEqual(sh.Days.OrderBy(t => t), days.OrderBy(t => t)) &&
                        sh.BusStop == BusStopComboBox.SelectionBoxItem.ToString() && 
                        sh.Time == ArrivalTimePicker.Time)
                    {
                        dialog = new MessageDialog("Such Arrival is already in your Schedule.");
                        await dialog.ShowAsync();
                        return;
                    }
                }
            else
                foreach (Shuttle sh in Schedule.Departures)
                {
                    if (Enumerable.SequenceEqual(sh.Days.OrderBy(t => t), days.OrderBy(t => t)) &&
                        sh.BusStop == BusStopComboBox.SelectionBoxItem.ToString() &&
                        sh.Time == ArrivalTimePicker.Time)
                    {
                        dialog = new MessageDialog("Such Departure is already in your Schedule.");
                        await dialog.ShowAsync();
                        return;
                    }
                }

            Shuttle shuttle = new Shuttle(
                    ArrivalTimePicker.Time, days, BusStopComboBox.SelectionBoxItem.ToString(),
                    DirectionComboBox.SelectionBoxItem.ToString());

            if (this.DirectionComboBox.SelectedIndex == 0)
            {
                JSONTools.FileName = Schedule.arrivalsFileName;
                Schedule.Arrivals.Add(shuttle);
                JSONTools.ListOfArrivals = Schedule.Arrivals;
            }
            else
            {
                JSONTools.FileName = Schedule.departuresFileName;
                Schedule.Departures.Add(shuttle);
                JSONTools.ListOfArrivals = Schedule.Departures;
            }

            await JSONTools.writeJsonAsync();

            if (this.DirectionComboBox.SelectedIndex == 0)
                Schedule.Arrivals = JSONTools.ListOfArrivals;
            else
                Schedule.Departures = JSONTools.ListOfArrivals;

            dialog = new MessageDialog("Shuttle was successfully added to your Schedule.");
            await dialog.ShowAsync();
        }
    }
}
