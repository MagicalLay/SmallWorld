﻿#pragma checksum "..\..\gameWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B98CBA24FBC67A26B0F5C86201FA3928"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34014
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Graphics;
using Jeu;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Graphics {
    
    
    /// <summary>
    /// gameWindow
    /// </summary>
    public partial class gameWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Graphics.gameWindow WindowInGame;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewbox main;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblYourTurn;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCurrentPlayer;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRemainingTurns;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblVictoryPointsP1;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblVictoryPointsP2;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel listUnitGrid;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid bgmapGrid;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mapGrid;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEndTurn;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid pauseMenu;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle MenuRectangle;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnContinue;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSaveGame;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnQuit;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGamePaused;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\gameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblVictory;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Graphics;component/gamewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\gameWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.WindowInGame = ((Graphics.gameWindow)(target));
            
            #line 6 "..\..\gameWindow.xaml"
            this.WindowInGame.KeyUp += new System.Windows.Input.KeyEventHandler(this.WindowInGame_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.main = ((System.Windows.Controls.Viewbox)(target));
            return;
            case 3:
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.lblYourTurn = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblCurrentPlayer = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblRemainingTurns = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblVictoryPointsP1 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblVictoryPointsP2 = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.listUnitGrid = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            this.bgmapGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.mapGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 12:
            this.btnEndTurn = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\gameWindow.xaml"
            this.btnEndTurn.Click += new System.Windows.RoutedEventHandler(this.btnEndTurn_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.pauseMenu = ((System.Windows.Controls.Grid)(target));
            return;
            case 14:
            this.MenuRectangle = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 15:
            this.btnContinue = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\gameWindow.xaml"
            this.btnContinue.Click += new System.Windows.RoutedEventHandler(this.btnContinue_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.btnSaveGame = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\gameWindow.xaml"
            this.btnSaveGame.Click += new System.Windows.RoutedEventHandler(this.btnSaveGame_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.btnQuit = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\gameWindow.xaml"
            this.btnQuit.Click += new System.Windows.RoutedEventHandler(this.btnQuit_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.lblGamePaused = ((System.Windows.Controls.Label)(target));
            return;
            case 19:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\gameWindow.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.lblVictory = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
