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
    }
}
