﻿#pragma checksum "C:\Users\asus\Documents\Visual Studio 2015\Projects\SmartClass\SmartClass\Controls\MessageShow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FFCC0719A315F9D7DE76A562596A9B47"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartClass.Controls
{
    partial class MessageShow : 
        global::Windows.UI.Xaml.Controls.UserControl, 
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
                    this.STRBDshow = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                    #line 14 "..\..\..\Controls\MessageShow.xaml"
                    ((global::Windows.UI.Xaml.Media.Animation.Storyboard)this.STRBDshow).Completed += this.STRBDshow_Completed;
                    #line default
                }
                break;
            case 2:
                {
                    this.STRBDpopin = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 3:
                {
                    this.STRBDpopout = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                    #line 51 "..\..\..\Controls\MessageShow.xaml"
                    ((global::Windows.UI.Xaml.Media.Animation.Storyboard)this.STRBDpopout).Completed += this.STRBDshow_Completed;
                    #line default
                }
                break;
            case 4:
                {
                    this.grid_GG = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 5:
                {
                    this.TXTBLKtitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.txt_GG = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.BTN = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 93 "..\..\..\Controls\MessageShow.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BTN).Click += this.Button_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.PLANEshow = (global::Windows.UI.Xaml.Media.PlaneProjection)(target);
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

