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
    /// Interaction logic for ResultPodiumPage.xaml
    /// </summary>
    public partial class ResultPodiumPage : Page
    {
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>()?.FirstOrDefault();

        public ResultPodiumPage()
        {
            InitializeComponent();
            Loaded += NavigationService_Navigated;
        }
        private void NavigationService_Navigated(object sender, RoutedEventArgs e)
        {
            OnLanguageSwitchRequested();
        }
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
