using Newtonsoft.Json;
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
using System.IO;
using static ProjectGameInteraction2DRacingGame.Components.LanguageManager;

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
            for (int i = 0; i < mainWindow.CarClasses.Count; i++)
            {
                LargeButtonSelectionComponentTest track = new LargeButtonSelectionComponentTest(mainWindow.CarClasses[i].GetName(), mainWindow.CarClasses[i].GetClassID(), FotoList[i]);
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
