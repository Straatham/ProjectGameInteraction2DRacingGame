using ProjectGameInteraction2DRacingGame.Components;
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
    /// Interaction logic for CircuitSelectiePage.xaml
    /// </summary>
    public partial class CircuitSelectiePage : Page
    {
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>()?.FirstOrDefault();

        const float listviewWidthDivider = 3.09f;

        public CircuitSelectiePage()
        {
            InitializeComponent();
            InitTracks();
            Input_LapCount.Text = mainWindow.gameInfo.GetRaceLaps().ToString();

            this.Height = mainWindow.Height;
            this.Width = mainWindow.Width;
        }
        private void Button_Terug_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainMenuPage setPage = new MainMenuPage();
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
        void InitTracks()
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    LargeButtonSelectionComponentTest track = new LargeButtonSelectionComponentTest($"Test Track {i}", i, @"MainScreen.jpg");
                    track.GetButton().Width = (mainWindow.Width - (CircuitListBox.Margin.Left + CircuitListBox.Margin.Right)) / listviewWidthDivider;
                    track.GetButton().Click += (object sender2, RoutedEventArgs e2) =>
                    {
                        MessageBox.Show($"CLICKED TRACK {track.GetID()}");

                        CategorySelectionPage setPage = new CategorySelectionPage();
                        NavigationService.Navigate(setPage);


                    };
                    CircuitListBox.Items.Add(track.GetButton());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex} Exiting....");
                    Environment.Exit(0);
                }
            }
        }
        private void IncreaseLaps(object sender, RoutedEventArgs e)
        {
            if (mainWindow.gameInfo.GetRaceLaps() >= 99)
                return;
            mainWindow.gameInfo.IncreaseLaps();
            Input_LapCount.Text = mainWindow.gameInfo.GetRaceLaps().ToString();
        }
        private void DecreaseLaps(object sender, RoutedEventArgs e)
        {
            if (mainWindow.gameInfo.GetRaceLaps() <= 1)
                return;
            mainWindow.gameInfo.DecreaseLaps();
            Input_LapCount.Text = mainWindow.gameInfo.GetRaceLaps().ToString();
        }
    }
}
