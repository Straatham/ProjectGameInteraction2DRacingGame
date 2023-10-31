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
using Newtonsoft.Json;
using System.IO;
using static ProjectGameInteraction2DRacingGame.Components.LanguageManager;

namespace ProjectGameInteraction2DRacingGame.Pages
{
    /// <summary>
    /// Interaction logic for LeaderbordPage.xaml
    /// </summary>
    public partial class LeaderbordPage : Page
    {
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>()?.FirstOrDefault();

        List<LeaderbordPrefabComponent> entries = new List<LeaderbordPrefabComponent>();  

        int CategorieID = 0, CircuitID = 0;
        public LeaderbordPage()
        {
            InitializeComponent();
            SetTrackAndCategoryName();
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
                MainMenuPage setPage = new MainMenuPage();
                NavigationService.Navigate(setPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} Exiting....");
                Environment.Exit(0);
            }
        }
        private void Button_IncreaseCircuit_Click(object sender, RoutedEventArgs e)
        {
            if (CircuitID >= 2) 
                CircuitID = 0;
            else CircuitID++;

            SetTrackAndCategoryName();
        }

        private void Button_DecreaseCircuit_Click(object sender, RoutedEventArgs e)
        {
            if (CircuitID <= 0)
                CircuitID = 2; //Set to max in circuit list
            else CircuitID--;

            SetTrackAndCategoryName();
        }

        public void SetTrackAndCategoryName()
        {
            KlasseListBox.Items.Clear();
            entries.Clear();
            InitLeaderbord();
            SelectedCircuitEnCategoryText.Content = $"CIRCUIT {CircuitID} (CATEGORIE {CategorieID})";
        }

        private void Button_IncreaseCategory_Click(object sender, RoutedEventArgs e)
        {
            if (CategorieID >= 2)
                CategorieID = 0;
            else CategorieID++;

            SetTrackAndCategoryName();
        }

        private void Button_DecreaseCategory_Click(object sender, RoutedEventArgs e)
        {
            if (CategorieID <= 0)
                CategorieID = 2; //Set to max in categorie list
            else CategorieID--;

            SetTrackAndCategoryName();
        }

        void InitLeaderbord()
        {
            //Temporary data, replace 15 with a list count of some sort
            for (int i = 0; i < 15; i++)
            {
                Frame frame = new();
                frame.Width = mainWindow.Width - KlasseListBox.Margin.Left - KlasseListBox.Margin.Right - 50;
                LeaderbordPrefabComponent component = new LeaderbordPrefabComponent(
                    0, 0, (i + 1), $"player {i}",
                    $"{(CircuitID + 1) * (CategorieID + 1)}:12.{100 + i}", frame.Width
                );
                component.SetGapToLeader(KlasseListBox.Items.Count == 0 ? component.GetRaceTime() : entries[0].GetRaceTime());
                frame.Content = component;

                entries.Add(component);
                KlasseListBox.Items.Add(frame);
            }
        }
    }
}
