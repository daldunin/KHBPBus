﻿#pragma checksum "D:\Work\KHBPbus\KHBPbus\ArrivalsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "143A5669A66689B47052AA0709BA999A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KHBPbus
{
    partial class ArrivalPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Grid element1 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 11 "..\..\..\ArrivalsPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)element1).Loaded += this.Grid_Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.ArrivalsHeaderText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.AddButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 13 "..\..\..\ArrivalsPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.AddButton).Click += this.AddButton_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.NextScreenButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 14 "..\..\..\ArrivalsPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.NextScreenButton).Click += this.button_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.ArrivalsListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 6:
                {
                    this.BusStopComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 35 "..\..\..\ArrivalsPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.BusStopComboBox).SelectionChanged += this.BusStopComboBox_SelectionChanged;
                    #line default
                }
                break;
            case 7:
                {
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.textBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    this.DayComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 42 "..\..\..\ArrivalsPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.DayComboBox).SelectionChanged += this.DayComboBox_SelectionChanged;
                    #line default
                }
                break;
            case 10:
                {
                    global::Windows.UI.Xaml.Controls.Grid element10 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 19 "..\..\..\ArrivalsPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)element10).Holding += this.Grid_Holding;
                    #line default
                }
                break;
            case 11:
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element11 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    #line 22 "..\..\..\ArrivalsPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element11).Click += this.EditClick;
                    #line default
                }
                break;
            case 12:
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element12 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    #line 23 "..\..\..\ArrivalsPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element12).Click += this.RemoveClick;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

