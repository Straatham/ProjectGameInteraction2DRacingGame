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

        const float listviewWidthDivider = 3.07f;

        public CircuitSelectiePage()
        {
            InitializeComponent();
            InitTracks();
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
            for (int i = 0; i < 4; i++)
            {
                CircuitSelectionComponentTest page = new CircuitSelectionComponentTest($"Test Track {i}", i, @"MainScreen.jpg");
                page.GetButton().Width = CircuitListBox.Width / listviewWidthDivider;
                page.GetButton().Click += (object sender2, RoutedEventArgs e2) =>
                {
                    MessageBox.Show($"CLICKED TRACK {page.GetID()}");
                };
                CircuitListBox.Items.Add(page.GetButton());
            }
        }
    }
}
