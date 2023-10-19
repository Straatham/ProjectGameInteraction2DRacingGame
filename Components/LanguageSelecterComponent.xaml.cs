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
        }
        //To DO
        void SetTitleTranslation()
        {
            //LanguageTitle.Content = "dic["Language"]"
        }

        public void SwitchLanguage(string languageCode)
        {
            ResourceDictionary dict = new()
            {
                Source = languageCode switch
                {
                    "en" => new Uri("..\\Resources\\Strings.en.xaml",
                                                      UriKind.Relative),
                    "frl" => new Uri("..\\Resources\\Strings.frl.xaml",
                                                           UriKind.Relative),
                    //idk, I'll find out eventually how to pass default case
                    "nl" => new Uri("..\\Resources\\Strings.nl.xaml",
                                                          UriKind.Relative),
                    _ => new Uri("..\\Resources\\Strings.nl.xaml",
                                            UriKind.Relative),
                }
            };
            this.Resources.MergedDictionaries.Add(dict);
        }

        private void Radio_English_Checked(object sender, RoutedEventArgs e)
        {
            SwitchLanguage("en");
        }

        private void Radio_Frysk_Checked(object sender, RoutedEventArgs e)
        {
            SwitchLanguage("frl");
        }

        private void Radio_Nederlands_Checked(object sender, RoutedEventArgs e)
        {
            SwitchLanguage("nl");
        }
    }
}
