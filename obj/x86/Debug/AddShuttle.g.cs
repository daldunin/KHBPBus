﻿#pragma checksum "D:\Work\KHBPbus\KHBPbus\AddShuttle.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0C58283720AE1F75149A0E083FF1FBAB"
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
    partial class AddShuttle : 
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
                    this.AddBusHeaderText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 2:
                {
                    this.PickTimeText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.PickDaysText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.PickBusStopText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.ArrivalTimePicker = (global::Windows.UI.Xaml.Controls.TimePicker)(target);
                }
                break;
            case 6:
                {
                    this.MondayCheckBox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 7:
                {
                    this.TuesdayCheckBox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 8:
                {
                    this.WednesdeyCheckBox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 9:
                {
                    this.ThursdayCheckBox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 10:
                {
                    this.FridayCheckBox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 11:
                {
                    this.SaturdayCheckBox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 12:
                {
                    this.SundayCheckBox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 13:
                {
                    this.BusStopComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 14:
                {
                    this.AddButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 27 "..\..\..\AddShuttle.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.AddButton).Click += this.button_Click;
                    #line default
                }
                break;
            case 15:
                {
                    this.BackButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 28 "..\..\..\AddShuttle.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BackButton).Click += this.button_Copy_Click;
                    #line default
                }
                break;
            case 16:
                {
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17:
                {
                    this.DirectionComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
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
