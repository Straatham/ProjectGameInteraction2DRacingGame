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
    /// Interaction logic for ResultPodiumPage.xaml
    /// </summary>
    public partial class ResultPodiumPage : Page
    {
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>()?.FirstOrDefault();

        public ResultPodiumPage()
        {
            InitializeComponent();
        }

        private void Button_Terug_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                mainWindow.gameInfo = new OOP.Session();
                mainWindow.MainFrameWindow.Content = new MainMenuPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} Exiting....");
                Environment.Exit(0);
            }
        }

        private void Button_Herstarten_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrameWindow.Content = new RaceScreenPage();
        }
    }
}
