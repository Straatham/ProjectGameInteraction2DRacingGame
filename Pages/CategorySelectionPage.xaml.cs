﻿using ProjectGameInteraction2DRacingGame.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectGameInteraction2DRacingGame.Pages
{
    /// <summary>
    /// Interaction logic for CategorySelectionPage.xaml
    /// </summary>
    public partial class CategorySelectionPage : Page
    {
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>()?.FirstOrDefault();

        const float listviewWidthDivider = 3.09f;
        public CategorySelectionPage()
        {
            InitializeComponent();
            InitClasses();
        }
        private void Button_Terug_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CircuitSelectiePage setPage = new CircuitSelectiePage();
                NavigationService.Navigate(setPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} Exiting....");
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Create the components for the circuits, add them to the scrollview and add the onClick function
        /// </summary>
        void InitClasses()
        {
            List<string> FotoList = new List<string>
            { "GroupGT3.jpg", "Motorcross.jpg", "TractorPulling.jpg"};
            List<string> NameList = new List<string>
            { "Auto Racing", "Motor Racing", "Tractor Racing"};
            for (int i = 0; i < 3; i++)
            {
                LargeButtonSelectionComponentTest track = new LargeButtonSelectionComponentTest(NameList[i], i, FotoList[i]);
                track.GetButton().Width = (mainWindow.Width - ( KlasseListBox.Margin.Left + KlasseListBox.Margin.Right)) / listviewWidthDivider;
                track.GetButton().Click += (object sender2, RoutedEventArgs e2) =>
                {
                    PlayerSetupPage setPage = new PlayerSetupPage();
                    NavigationService.Navigate(setPage);
                };
                KlasseListBox.Items.Add(track.GetButton());
            }
        }
    }
}