using ProjectGameInteraction2DRacingGame.Public;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
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

namespace ProjectGameInteraction2DRacingGame.Components
{
    /// <summary>
    /// Interaction logic for PlayerSetupComponent.xaml
    /// </summary>
    public partial class PlayerSetupComponent : Page
    {

        int ID;
        int SelectedCar;
        bool CanReady = false, isReady = false;

        int CarId = 0;

        Color CurrentColor;

        int _CarID
        {
            set
            {
                CarId = value;
                if (OnCarIDChange != null)
                    OnCarIDChange();
            }
            get { return CarId; }
        }
        public event OnVariableChangeDelegate OnCarIDChange;

        bool _isReady
        {
            set
            {
                isReady = value;
                if (OnPlayerReadyChange != null)
                    OnPlayerReadyChange();
            }
            get { return isReady; }
        }
        public delegate void OnVariableChangeDelegate();
        public event OnVariableChangeDelegate OnPlayerReadyChange;

        //Non player related things
        string templateText = "Fill in Name";

        public PlayerSetupComponent(int i)
        {
            ID = i;
            InitializeComponent();
            FixCorrectTextButtons();
            ResetButtonText();
            PlayerNameInput.GotFocus += OnPlayerNameInputSelect;
            PlayerNameInput.LostFocus += OnlayerNameInputSelectionChanged;
        }

        void FixCorrectTextButtons()
        {
            Button_Decrease.Content = "<";
            Button_Increase.Content = ">";
        }
        void ResetButtonText()
        {
            PlayerNameInput.Text = templateText;
        }
        public void SetAllObjectsToInActive()
        {
            Button_Ready.Visibility = Visibility.Hidden;
            PlayerNameInput.IsEnabled = false;
        }
        public void AddColors(List<Color> colors)
        {
            foreach (Color color in colors)
            {
                Button btn = new()
                { 
                    Width = 85,
                    Height = 85,
                    Background = new SolidColorBrush(color),
                    Content = "",
                    BorderThickness = new Thickness(0)
                };
                btn.Click += delegate { SetCarImage(((SolidColorBrush)btn.Background).Color); };
                ColorListView.Items.Add(btn);
            }
        }

        void OnPlayerNameInputSelect(object sender, EventArgs e)
        {
            if (PlayerNameInput.Text == templateText)
                PlayerNameInput.Text = "";
        }
        void OnlayerNameInputSelectionChanged(object sender, EventArgs e)
        {
            if (PlayerNameInput.Text == "")
                ResetButtonText();
        }

        public void SetIsReady()
        {
            _isReady = true;
        }
        public string GetPlayerName() => PlayerNameInput.Text;
        public bool GetIsReady() => _isReady;
        public Button GetReadyButton() => Button_Ready;
        public Button GetIncreaseCarButton() => Button_Increase;
        public Button GetDecreaseCarButton() => Button_Decrease;

        public void SetCarID(int ID)
        {
            _CarID = ID;
        }
        public int GetCarID() => _CarID;

        //TO DO - REGEX CHECK
        public bool GetCanReady() => !string.IsNullOrEmpty(PlayerNameInput.Text) && PlayerNameInput.Text != templateText;

        public void SetCarImage(Color color)
        {
            //TO DO - Change code to the following example once images are working
            //Carviewer_Image.Fill = new BitmapImage(new Uri(@"/Images/foo.png", UriKind.Relative));

            //TEMP
            var imageSource = $"SportsCar1_{CarId}.png";
            var path = Path.Combine("/Images/Autos", imageSource);
            Uri uri = new Uri(path, UriKind.Relative);

            CurrentColor = color;
            Carviewer_Image_Source.Source = ImageColorConverter.ConvertColorToSource(uri, color);
        }
        public Color GetCarColor() => CurrentColor;
    }
}
