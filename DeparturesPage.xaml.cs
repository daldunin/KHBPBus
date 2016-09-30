﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
            if (BusStopComboBox.SelectionBoxItem != null && DayComboBox.SelectionBoxItem != null)
                foreach (Shuttle departure in Schedule.Departures)
                {
                    if (departure.Direction == "From KHBP" && departure.BusStop == BusStopComboBox.SelectionBoxItem.ToString())
                    {
                        if (departure.isActiveOnDay(DayComboBox.SelectionBoxItem.ToString()))
                            found.Add(departure);
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
                DeparturesListView.Items.Add(departure.Time.ToString(@"hh\:mm"));
            }
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

        private void CommandInvokedHandler(IUICommand command)
        {
            // Display message showing the label of the command that was invoked
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
    }
}