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
using Newtonsoft.Json;
using System.IO;
using static ProjectGameInteraction2DRacingGame.Components.LanguageManager;

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
            Loaded += NavigationService_Navigated;
            Input_LapCount.Text = mainWindow.gameInfo.GetRaceLaps().ToString();

            this.Height = mainWindow.Height;
            this.Width = mainWindow.Width;
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
            for (int i = 0; i < mainWindow.Tracks.Count; i++)
            {
                try
                {
                    LargeButtonSelectionComponentTest track = new LargeButtonSelectionComponentTest(mainWindow.Tracks[i].GetName(), mainWindow.Tracks[i].GetTrackID(), @"Inje.jpg");
                    track.GetButton().Width = (mainWindow.Width - (CircuitListBox.Margin.Left + CircuitListBox.Margin.Right)) / listviewWidthDivider;
                    track.GetButton().Click += (object sender2, RoutedEventArgs e2) =>
                    {
                        mainWindow.gameInfo.SetTrackID(track.GetID());
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
