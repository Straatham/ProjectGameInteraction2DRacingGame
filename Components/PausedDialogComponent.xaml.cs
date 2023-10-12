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
    /// Interaction logic for PausedDialogComponent.xaml
    /// </summary>
    public partial class PausedDialogComponent : Page
    {
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>()?.FirstOrDefault();

        Frame frame;

        public PausedDialogComponent(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
        }

        private void Button_Leave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.gameInfo.players.Clear();
                mainWindow.MainFrameWindow.Content = new MainMenuPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} Exiting....");
                Environment.Exit(0);
            }
        }

        private void Button_Resume_Click(object sender, RoutedEventArgs e)
        {
            frame.Visibility = Visibility.Hidden;
        }

        private void Button_Restart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.gameInfo.players.Clear();
                mainWindow.MainFrameWindow.Content = new RaceScreenPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} Exiting....");
                Environment.Exit(0);
            }
        }
    }
}
