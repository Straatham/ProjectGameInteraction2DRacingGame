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
    /// Interaction logic for SpelInstructiesPage.xaml
    /// </summary>
    public partial class SpelInstructiesPage : Page
    {
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>()?.FirstOrDefault();
        public SpelInstructiesPage()
        {
            InitializeComponent();
            Loaded += OnLoaded;
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

        void OnLoaded(object sender, EventArgs e)
        {
            //Change to full info string later.
            GameInfoText.Text = "Welkom Bij Razendsnelle Actievolle Competitive Energieke Supersonische Perfecte Extraordinaire Landrace\r\nHieronder vind je een stap voor stap uitleg over hoe je deze game speelt.\r\n\r\nJe kan een circuit kiezen door op de foto van je gewenste circuit te drukken die kan vinden als je de game start.\r\n\r\nTerwijl je een circuit selecteert heb je onder in je beeld ook een rondes nummer staan. \r\nJe kan het aantal rondes hoger maken door op \"+\" te drukken en lager door op \"-\" te drukken\r\n\r\nNadat je een circuit geselecteerd hebt mag je een voertuig klasse kiezen. \r\nEr zijn 3 voertuig klassen Auto, Motor, Trekker.\r\nOm een voertuig klasse te selecteren druk je op de bijstaande foto van de gewenste klasse.\r\n\r\nNadat je een voertuig klasse hebt geselecteerd kan ieder persoon zijn eigen auto aanpassen.\r\nDoor op de \"<\" en de \">\" pijltjes te drukken naast je voertuig kan je een andere soort voertuig kiezen.\r\nOok kan je de kleur van je voertuig aanpassen door op een kleur onder het voertuig te drukken.\r\n\r\nDe besturing van de voertuigen staat vermeld in de afbeelding.\r\n\r\nJe wint de race door zo snel mogelijk van de start een rondje door de map te rijden en de finish aan te raken.\r\n\r\nJe kan de race herstarten door op pauze te drukken tijdens de race en dan op \"herstarten\" te drukken";
        }

        private void GameInfoText_SelectionChanged(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            //((TextBox)sender).SelectionLength = 0;
        }
    }
}
