﻿using ProjectGameInteraction2DRacingGame.Pages;
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

namespace ProjectGameInteraction2DRacingGame.Components
{
    /// <summary>
    /// Interaction logic for LanguageSelecterComponent.xaml
    /// </summary>
    public partial class LanguageSelecterComponent : Page
    {
        public LanguageSelecterComponent()
        {
            InitializeComponent();
            SetTitleTranslation();
            LanguageManager.Instance.LanguageSwitchRequested += OnLanguageSwitchRequested;
        }
        //To DO
        void SetTitleTranslation()
        {
            //LanguageTitle.Content = "dic["Language"]"
        }

        public void OnLanguageSwitchRequested(string languageCode)
        {
            ResourceDictionary dict = new ResourceDictionary()
            {
                Source = new Uri($"../Resources/Strings.{languageCode}.xaml", UriKind.Relative)
            };

            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(dict);
        }

        private void Radio_English_Checked(object sender, RoutedEventArgs e)
        {
            var languageManager = LanguageManager.Instance;
            languageManager.SwitchLanguage("en");
        }

        private void Radio_Frysk_Checked(object sender, RoutedEventArgs e)
        {
            var languageManager = LanguageManager.Instance;
            languageManager.SwitchLanguage("frl");
        }

        private void Radio_Nederlands_Checked(object sender, RoutedEventArgs e)
        {
            var languageManager = LanguageManager.Instance;
            languageManager.SwitchLanguage("nl");
        }
    }

    public class LanguageManager : Page
    {
        // Singleton-patroon
        private static LanguageManager instance;
        private string selectedLanguage = "nl"; // Standaardtaal is Nederlands

        private LanguageManager()
        {
            // Privéconstructor om een enkele instantie te garanderen
        }

        public static LanguageManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LanguageManager();
                }
                return instance;
            }
        }

        public string SelectedLanguage
        {
            get { return selectedLanguage; }
            set
            {
                if (selectedLanguage != value)
                {
                    selectedLanguage = value;
                    SwitchLanguage(selectedLanguage);
                }
            }
        }

        public event Action<string> LanguageSwitchRequested;

        public void SwitchLanguage(string languageCode)
        {
            ResourceDictionary dict = new ResourceDictionary()
            {
                Source = new Uri($"../Resources/Strings.{languageCode}.xaml", UriKind.Relative)
            };

            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(dict);
            LanguageSwitchRequested?.Invoke(languageCode);
            SaveSelectedLanguage(languageCode);
        }

        // Een eenvoudige klasse om de taalcode op te slaan in JSON
        public class LanguageData
        {
            public string LanguageCode { get; set; }
        }

        public void SaveSelectedLanguage(string languageCode)
        {
            // Creëer een object om de taalcode op te slaan
            var languageData = new LanguageData { LanguageCode = languageCode };

            // Serialiseer het object naar JSON
            string json = JsonConvert.SerializeObject(languageData);

            // Sla het JSON-bestand op in de cache
            File.WriteAllText("cache.json", json);
        }

        public string LoadSelectedLanguage()
        {
            if (File.Exists("cache.json"))
            {
                // Lees de opgeslagen JSON uit het cachebestand
                string json = File.ReadAllText("cache.json");

                // Deserialiseer het JSON naar een object
                var languageData = JsonConvert.DeserializeObject<LanguageData>(json);
                MessageBox.Show("LoadSelectedLanguage: File.Exists");

                return languageData.LanguageCode;
            }

            return "nl"; // Stel een standaard taalcode in als er niets is opgeslagen
        }
        public string GetSelectedLanguage()
        {
            // Implementeer logica om de opgeslagen taalcode op te halen
            // bijv. uit applicatie-instellingen
            return LoadSelectedLanguage();
        }

    }


}
