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
    /// Interaction logic for LeaderbordPage.xaml
    /// </summary>
    public partial class LeaderbordPage : Page
    {
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>()?.FirstOrDefault();
        public LeaderbordPage()
        {
            InitializeComponent();
            InitLeaderbord();
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
        void InitLeaderbord()
        {
            //Temporary data, replace 15 with a list count
            for (int i = 0; i < 15; i++)
            {
                LeaderbordEntryComponent component = new LeaderbordEntryComponent(
                    0, 0, (i + 1), $"player {i}", 
                    $"1:12.{100 + i}",
                    "1:12.100");
                //MessageBox.Show(component.GetGrid().Width.ToString());
                KlasseListBox.Items.Add(component.GetGrid());
            }
        }
    }
}
