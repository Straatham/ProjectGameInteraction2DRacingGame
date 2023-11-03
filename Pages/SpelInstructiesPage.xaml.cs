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
using Newtonsoft.Json;
using System.IO;
using static ProjectGameInteraction2DRacingGame.Components.LanguageManager;

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
            Loaded += NavigationService_Navigated;
        }
        private void NavigationService_Navigated(object sender, RoutedEventArgs e)
        {
            OnLanguageSwitchRequested();
        }
        public string languageCode;
        private string unused;

        public string LoadSelectedLanguage()
        {
            if (File.Exists("cache.json"))
            {
                // Lees de opgeslagen JSON uit het cachebestand
                string json = File.ReadAllText("cache.json");

                // Deserialiseer het JSON naar een object
                var languageData = JsonConvert.DeserializeObject<LanguageData>(json);

                return languageData.LanguageCode;
            }

            return "nl"; // Stel een standaard taalcode in als er niets is opgeslagen
        }
        public void OnLanguageSwitchRequested()
        {
            string languageCode = LoadSelectedLanguage();
            ResourceDictionary dict = new()
            {
                Source = new Uri($"../Resources/Strings.{languageCode}.xaml", UriKind.Relative)
            };

            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(dict);
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
            this.languageCode = LoadSelectedLanguage();
            unused = languageCode switch
            {
                "nl" =>
                    GameInfoText.Text = "Welkom bij Razendsnelle Actievolle Competitive Energieke Supersonische Perfecte Extraordinaire Landrace\r\nHieronder vind je een stap voor stap uitleg over hoe je deze game speelt.\r\n\r\nJe kan een circuit kiezen door op de foto van je gewenste circuit te drukken die kan vinden als je de game start.\r\n\r\nTerwijl je een circuit selecteert heb je onder in je beeld ook een rondes nummer staan. \r\nJe kan het aantal rondes hoger maken door op \"+\" te drukken en lager door op \"-\" te drukken\r\n\r\nNadat je een circuit geselecteerd hebt mag je een voertuig klasse kiezen. \r\nEr zijn 3 voertuig klassen Auto, Motor, Trekker.\r\nOm een voertuig klasse te selecteren druk je op de bijstaande foto van de gewenste klasse.\r\n\r\nNadat je een voertuig klasse hebt geselecteerd kan ieder persoon zijn eigen auto aanpassen.\r\nDoor op de \"<\" en de \">\" pijltjes te drukken naast je voertuig kan je een andere soort voertuig kiezen.\r\nOok kan je de kleur van je voertuig aanpassen door op een kleur onder het voertuig te drukken.\r\n\r\nDe besturing van de voertuigen staat vermeld in de afbeelding.\r\n\r\nJe wint de race door zo snel mogelijk van de start een rondje door de map te rijden en de finish aan te raken.\r\n\r\nJe kan de race herstarten door op pauze te drukken tijdens de race en dan op \"herstarten\" te drukken",
                "frl" =>
                    GameInfoText.Text = "Wolkom By Razendsnelle Actievolle Competitive Energieke Supersonische Perfecte Extraordinaire Landrace\r\nHjirûnder fynsto in stap foar stap útlis oer hoe 'sto dizze game spilet.\r\n\r\nDo kinst in circuit kieze troch op de foto fan dy winske circuit te drukken dy kin fine asto de game start.\r\n\r\nWylst dy in circuit selecteert hasto ûnder yn dyn byld ek in rondes nûmer stean. \r\nDo kinst it oantal rondes heger meitsjen troch op \"+\" te drukken en leger troch op \"-\" te drukken\r\n\r\nNeidat dy in circuit selektearre hast mei dyn in reau klasse kieze. \r\nDer binne 3 reau klassen Auto, Moter, Lûker.\r\nOm in reau klasse te selektearjen drok do op de bijstaande foto fan de winske klasse.\r\n\r\nNeidat dy in reau klasse hast selektearre kin elk persoan syn eigen auto oanpasse.\r\nTroch op de \"<\" en \">\" pijltjes te drukken njonkensto reau kinsto in oare soart reau kieze.\r\nEk kinsto de kleur fan dy reau oanpasse troch op in kleur ûnder it reau te drukken.\r\n\r\nDe kontrôles fan de reau stiet neamd yn de ôfbylding.\r\n\r\nDo wint de race troch sa fluch mooglik fan de start in rûntsje troch de map te ride en de finish oan te reitsjen.\r\n\r\nDo kinst de race herstarten troch op skoft te drukken wilens de race en dan op \"herstartsje\" te drukken",
                "en" =>
                    GameInfoText.Text = "Welcome to Razendsnelle Actievolle Competitive Energieke Supersonische Perfecte Extraordinaire Landrace\r\nBelow you will find a step-by-step explanation of how to play this game.\r\n\r\nYou can choose a circuit by clicking on the photo of pressing your desired circuit, which can be found when you start the game.\r\n\r\nWhile you select a circuit you will also have a lap number at the bottom of your screen.\r\nYou can increase the number of laps by pressing \"+\" and down by pressing \"-\" \r\n\r\nAfter you have selected a circuit you can choose a vehicle class. \r\nThere are 3 vehicle classes: Car, Motorcycle, Tractor.\r\nTo select a vehicle class, press on the accompanying photo of the desired class.\r\n\r\nAfter you have selected a vehicle class, each person can customize their own car.\r\nBy pressing the By pressing \"<\" and the \">\" arrows next to your vehicle you can choose a different type of vehicle.\r\nYou can also adjust the color of your vehicle by pressing a color under the vehicle.\r \n\r\nThe controls of the vehicles are shown in the image.\r\n\r\nYou win the race by driving around the map as quickly as possible from the start and touching the finish line.\r\n\r\nYou can restart the race by pressing pause during the race and then pressing \"restart\"",
                _ => GameInfoText.Text = "Welkom bij Razendsnelle Actievolle Competitive Energieke Supersonische Perfecte Extraordinaire Landrace\r\nHieronder vind je een stap voor stap uitleg over hoe je deze game speelt.\r\n\r\nJe kan een circuit kiezen door op de foto van je gewenste circuit te drukken die kan vinden als je de game start.\r\n\r\nTerwijl je een circuit selecteert heb je onder in je beeld ook een rondes nummer staan. \r\nJe kan het aantal rondes hoger maken door op \"+\" te drukken en lager door op \"-\" te drukken\r\n\r\nNadat je een circuit geselecteerd hebt mag je een voertuig klasse kiezen. \r\nEr zijn 3 voertuig klassen Auto, Motor, Trekker.\r\nOm een voertuig klasse te selecteren druk je op de bijstaande foto van de gewenste klasse.\r\n\r\nNadat je een voertuig klasse hebt geselecteerd kan ieder persoon zijn eigen auto aanpassen.\r\nDoor op de \"<\" en de \">\" pijltjes te drukken naast je voertuig kan je een andere soort voertuig kiezen.\r\nOok kan je de kleur van je voertuig aanpassen door op een kleur onder het voertuig te drukken.\r\n\r\nDe besturing van de voertuigen staat vermeld in de afbeelding.\r\n\r\nJe wint de race door zo snel mogelijk van de start een rondje door de map te rijden en de finish aan te raken.\r\n\r\nJe kan de race herstarten door op pauze te drukken tijdens de race en dan op \"herstarten\" te drukken",
            };
        }

        private void GameInfoText_SelectionChanged(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            //((TextBox)sender).SelectionLength = 0;
        }
    }
}
