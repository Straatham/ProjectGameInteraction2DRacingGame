﻿#pragma checksum "..\..\..\..\Components\PlayerSetupComponent.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56F03224D50FC54ECFD0DDB27F8431DC997D2A18"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectGameInteraction2DRacingGame.Components;
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


namespace ProjectGameInteraction2DRacingGame.Components {
    
    
    /// <summary>
    /// PlayerSetupComponent
    /// </summary>
    public partial class PlayerSetupComponent : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Components\PlayerSetupComponent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PlayerNameInput;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Components\PlayerSetupComponent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Decrease;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Components\PlayerSetupComponent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Carviewer_Image;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Components\PlayerSetupComponent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Increase;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Components\PlayerSetupComponent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ColorListView;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Components\PlayerSetupComponent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Ready;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectGameInteraction2DRacingGame;V1.0.0.0;component/components/playersetupcomp" +
                    "onent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Components\PlayerSetupComponent.xaml"
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
            this.PlayerNameInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Button_Decrease = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.Carviewer_Image = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.Button_Increase = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.ColorListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.Button_Ready = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

