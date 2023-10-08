using System;
using System.Collections.Generic;
using System.Linq;
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
            SetTranslationRadioButton();
            SetAudioLevels();
        }

        /// <summary>
        /// Set the slider values based on audio values
        /// </summary>
        void SetAudioLevels()
        {
            //Set these values to loaded values later
            audioSliders[0].Value = 5f;
            audioSliders[1].Value = 4f;
            audioSliders[2].Value = 6f;
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
            int translation = CheckRadioButtons();
            float motor = (float)audioSliders[0].Value;
            float music = (float)audioSliders[1].Value;
            float effecten = (float)audioSliders[2].Value;
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
