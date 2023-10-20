using ProjectGameInteraction2DRacingGame.Pages;
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
        }

    }


}
