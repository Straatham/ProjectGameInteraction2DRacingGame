﻿using Newtonsoft.Json;
using ProjectGameInteraction2DRacingGame.Components;
using ProjectGameInteraction2DRacingGame.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ProjectGameInteraction2DRacingGame.Components.LanguageManager;

namespace ProjectGameInteraction2DRacingGame.Pages
{
    /// <summary>
    /// Interaction logic for InstellingenPage.xaml
    /// </summary>
    public partial class InstellingenPage : Page
    {
        private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>()?.FirstOrDefault();
        List<RadioButton> translationRadioButtons = new List<RadioButton>();
        List<Slider> audioSliders = new List<Slider>();
        public InstellingenPage()
        {
            InitializeComponent();
            Loaded += LoadedPage;
            Loaded += NavigationService_Navigated;
            LanguageManager.Instance.LanguageSwitchRequested += OnLanguageSwitchRequested;
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
        public void OnLanguageSwitchRequested(string? languageCode = null)
        {
            languageCode ??= LoadSelectedLanguage();
            ResourceDictionary dict = new()
            {
                Source = new Uri($"../Resources/Strings.{languageCode}.xaml", UriKind.Relative)
            };

            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(dict);
        }

        /// <summary>
        /// Finds all necessary radioButtons in the frame for translation and audio levels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void LoadedPage(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton button in FindVisualChildren<RadioButton>(TranslationFrame))
            {
                if ((VisualTreeHelper.GetParent(button) as StackPanel).Name == "translationPanel")
                    translationRadioButtons.Add(button);
            }
            foreach (Slider button in FindVisualChildren<Slider>(AudioFrame))
            {
                if ((VisualTreeHelper.GetParent(button) as StackPanel).Name == "AudioPanel")
                    audioSliders.Add(button);
            }
            SetTranslationRadioButton(GameSettings.GetTranslation());
            SetAudioLevels();
        }

        /// <summary>
        /// Set the slider values based on audio values
        /// </summary>
        void SetAudioLevels()
        {
            audioSliders[0].Value = GameSettings.GetCarVolume();
            audioSliders[1].Value = GameSettings.GetMusicVolume();
            audioSliders[2].Value = GameSettings.GetEffectsVolume();
        }
        void SetTranslationRadioButton(int value = 0)
        {
            translationRadioButtons[value].IsChecked = true;
        }

        private void Button_Terug_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainMenuPage setPage = new MainMenuPage();
                NavigationService.Navigate(setPage);
            }
            catch
            {
                MessageBox.Show($"{mainWindow} is null (not found). Exiting....");
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// When pressed, saves and overrides values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Opslaan_Click(object sender, RoutedEventArgs e)
        {
            GameSettings.SetTranslation(CheckRadioButtons());
            GameSettings.SetCarVolume((float)audioSliders[0].Value);
            GameSettings.SetMusicVolume((float)audioSliders[1].Value);
            GameSettings.SetEffectsVolume((float)audioSliders[2].Value);
            GameSettingsImporter.WriteToFile();
        }

        /// <summary>
        /// Checks which radio button is selected, then return the translation index (0,1,2)
        /// </summary>
        public int CheckRadioButtons() => translationRadioButtons.FindIndex(x => x.IsChecked == true);

        /// <summary>
        /// Finds the children (that are visible) of an element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
