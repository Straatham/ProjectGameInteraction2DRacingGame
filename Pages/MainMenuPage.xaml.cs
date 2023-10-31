using ProjectGameInteraction2DRacingGame.Components;
using ProjectGameInteraction2DRacingGame.OOP;
using ProjectGameInteraction2DRacingGame.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

namespace ProjectGameInteraction2DRacingGame.Pages
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>()?.FirstOrDefault();
        public MainMenuPage()
        {
            InitializeComponent();
            mainWindow.player.Play();
            Loaded += YourPage_Loaded;
        }
        private void YourPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Registreer voor de Navigated-event
            NavigationService.Navigated += OnLanguageSwitchRequestedtwo;
            MessageBox.Show("YourPage_Loaded");
        }
        public void OnLanguageSwitchRequested(string languageCode)
        {
            ResourceDictionary dict = new()
            {
                Source = new Uri($"../Resources/Strings.{languageCode}.xaml", UriKind.Relative)
            };

            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(dict);
            MessageBox.Show($"OnLanguageSwitchRequested: {languageCode}");
        }
        public void OnLanguageSwitchRequestedtwo(object sender, NavigationEventArgs e)
        {
            string languageCode = LanguageManager.Instance.GetSelectedLanguage();
            ResourceDictionary dict = new()
            {
                Source = new Uri($"../Resources/Strings.{languageCode}.xaml", UriKind.Relative)
            };

            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(dict);
            MessageBox.Show($"OnLanguageSwitchRequestedtwo: {languageCode}");
        }
        private void ButtonSpeel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.gameInfo = new Session();
                CircuitSelectiePage setPage = new CircuitSelectiePage();
                NavigationService.Navigate(setPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} - Exiting....");
                Button_VerlaatHetSpel.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }

        private void Button_Instellingen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InstellingenPage setPage = new InstellingenPage();
                NavigationService.Navigate(setPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} - Exiting....");
                Environment.Exit(0);
            }
        }
        private void Button_Leaderbord_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LeaderbordPage setPage = new LeaderbordPage();
                NavigationService.Navigate(setPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} - Exiting....");
                Environment.Exit(0);
            }
        }
        private void Button_SpelInstructies_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SpelInstructiesPage setPage = new SpelInstructiesPage();
                NavigationService.Navigate(setPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} - Exiting....");
                Environment.Exit(0);
            }
        }

        private void Button_VerlaatHetSpel_Click(object sender, RoutedEventArgs e)
        {
            GameSettingsImporter.WriteToFile();
            Environment.Exit(0);
        }
    }
}
