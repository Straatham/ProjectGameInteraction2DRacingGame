using ProjectGameInteraction2DRacingGame.Components;
using ProjectGameInteraction2DRacingGame.OOP;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
    /// Interaction logic for PlayerSetupPage.xaml
    /// </summary>
    public partial class PlayerSetupPage : Page
    {
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>()?.FirstOrDefault();
        List<PlayerSetupComponent> players = new List<PlayerSetupComponent>();
        public PlayerSetupPage()
        {
            InitializeComponent();
            GeneratePlayerSetup();
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
                mainWindow.gameInfo.ClearPlayerList();
                mainWindow.MainFrameWindow.Content = new CategorySelectionPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} Exiting....");
                Environment.Exit(0);
            }
        }
        void GeneratePlayerSetup()
        {
            for (int i = 0; i < 2; i++) 
            {
                AddPlayerSetup(i);
            }
        }

        /// <summary>
        /// Add a player to the panel to race with
        /// </summary>
        /// <param name="i"></param>
        void AddPlayerSetup(int i)
        {
            PlayerSetupComponent playerSetupComponent = new(i);
            playerSetupComponent.AddColors(mainWindow.GameColors);
            playerSetupComponent.OnPlayerReadyChange += CheckAllPlayersReady;

            //Delegate method to update car picture once CarID has changed
            playerSetupComponent.OnCarIDChange += delegate { 
                playerSetupComponent.SetCarImage(playerSetupComponent.GetCarColor()); 
            };

            //Event when player is ready to play
            playerSetupComponent.GetReadyButton().Click += (object sender2, RoutedEventArgs e2) =>
            {
                if (playerSetupComponent.GetCanReady())
                {
                    playerSetupComponent.SetAllObjectsToInActive();
                    playerSetupComponent.SetIsReady();
                    Player player = new Player(0, 0, 0, 0, playerSetupComponent.GetPlayerName(), null, new SolidColorBrush());
                    mainWindow.gameInfo.AddPlayer(player);
                }
            };            
            
            //Event when player presses the increase button when selecting car
            playerSetupComponent.GetIncreaseCarButton().Click += (object sender2, RoutedEventArgs e2) =>
            {
                //TO DO : Change int to category total cars
                if (playerSetupComponent.GetCarID() >= 19)
                    playerSetupComponent.SetCarID(0);
                else
                    playerSetupComponent.SetCarID(playerSetupComponent.GetCarID() + 1);
            };

            //Event when player presses the decrease button when selecting car
            playerSetupComponent.GetDecreaseCarButton().Click += (object sender2, RoutedEventArgs e2) =>
            {
                //TO DO : Change int to category total cars
                if (playerSetupComponent.GetCarID() < 1)
                    playerSetupComponent.SetCarID(19);
                else
                    playerSetupComponent.SetCarID(playerSetupComponent.GetCarID() - 1);
            };

            players.Add(playerSetupComponent);
            Frame frame = new()
            {
                Width = (mainWindow.Width - (PlayerListBox.Margin.Left + PlayerListBox.Margin.Right)) / 2 - 20,
                
                Content = playerSetupComponent
            };
            PlayerListBox.Items.Add(frame);
        }
        void AddPlayerSetupButtonClick(object sender, RoutedEventArgs e)
        {
            if (PlayerListBox.Items.Count < 4)//Max is 4 players
                AddPlayerSetup(PlayerListBox.Items.Count);
        }
        void RemovePlayerButtonClick(object sender, RoutedEventArgs e)
        {
            if (PlayerListBox.Items.Count > 2) //Min is 2 players
            {
                PlayerListBox.Items.RemoveAt(PlayerListBox.Items.Count - 1);
                players.RemoveAt(players.Count - 1);
            }
        }
        void CheckAllPlayersReady()
        {
            if(players.All(x => x.GetIsReady()))
            {
                Button_StartGame.Visibility = Visibility.Visible;
                Button_Terug.Visibility = Visibility.Hidden;
                RemovePlayerButton.IsEnabled = false;
                AddNewPlayerButton.IsEnabled = false;
            }
        }
        void StartGameButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.player.Stop();
                RaceScreenPage setPage = new RaceScreenPage();
                NavigationService.Navigate(setPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} Exiting....");
                Environment.Exit(0);
            }
        }
    }
}
