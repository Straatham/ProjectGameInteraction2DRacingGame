﻿#pragma checksum "..\..\..\..\Pages\InstellingenPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54808DD1219D281BE4D11FB32491554A1F0EA0C5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectGameInteraction2DRacingGame.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ProjectGameInteraction2DRacingGame.Pages {
    
    
    /// <summary>
    /// InstellingenPage
    /// </summary>
    public partial class InstellingenPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Pages\InstellingenPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame TranslationFrame;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Pages\InstellingenPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame AudioFrame;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Pages\InstellingenPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Terug;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Pages\InstellingenPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Opslaan;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjectGameInteraction2DRacingGame;V1.0.0.0;component/pages/instellingenpage.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\InstellingenPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TranslationFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            this.AudioFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 3:
            this.Button_Terug = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Pages\InstellingenPage.xaml"
            this.Button_Terug.Click += new System.Windows.RoutedEventHandler(this.Button_Terug_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Button_Opslaan = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Pages\InstellingenPage.xaml"
            this.Button_Opslaan.Click += new System.Windows.RoutedEventHandler(this.Button_Opslaan_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

