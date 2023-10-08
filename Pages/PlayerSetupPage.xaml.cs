using ProjectGameInteraction2DRacingGame.Components;
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
        }
        private void Button_Terug_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CategorySelectionPage setPage = new CategorySelectionPage();
                NavigationService.Navigate(setPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} Exiting....");
                Environment.Exit(0);
            }
        }
        void GeneratePlayerSetup()
        {
            for (int i = 0; i < 3; i++) 
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
            playerSetupComponent.GetReadyButton().Click += (object sender2, RoutedEventArgs e2) =>
            {
                if (playerSetupComponent.GetCanReady())
                {
                    playerSetupComponent.SetAllObjectsToInActive();
                    MessageBox.Show($"{playerSetupComponent.GetPlayerName()} is ready to play!");
                    playerSetupComponent.SetIsReady();
                }
            };
            players.Add(playerSetupComponent);
            Frame frame = new()
            {
                Width = PlayerListBox.Width / 2 - 20,
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
            MessageBox.Show("STARTED GAME!!!!");
        }
    }
}
