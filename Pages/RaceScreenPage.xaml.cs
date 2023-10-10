using ProjectGameInteraction2DRacingGame.Components;
using ProjectGameInteraction2DRacingGame.Public;
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

namespace ProjectGameInteraction2DRacingGame.Pages
{
    /// <summary>
    /// Interaction logic for RaceScreenPage.xaml
    /// </summary>
    public partial class RaceScreenPage : Page
    {
        MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>()?.FirstOrDefault();

        List<PlayerRaceTickerComponent> players = new List<PlayerRaceTickerComponent>();
        List<Frame> positionFrames = new List<Frame>();

        public RaceScreenPage()
        {
            InitializeComponent();

            PausedFrame.Content = new PausedDialogComponent(PausedFrame);

            //Add this seperately as FindVisualChildren doesn't work properly
            positionFrames.Add(Position_1);
            positionFrames.Add(Position_2);
            positionFrames.Add(Position_3);
            positionFrames.Add(Position_4);
            DisplayPlayersInTower();
        }

        /// <summary>
        /// Display players in random position order
        /// </summary>
        void DisplayPlayersInTower()
        {
            mainWindow.gameInfo.players.ShuffleMe();

            for (int i = 0; i < mainWindow.gameInfo.players.Count; i++)
            {
                PlayerRaceTickerComponent tickerItem = new PlayerRaceTickerComponent(Brushes.White.Color, i, $"{mainWindow.gameInfo.players[i]}");

                //Stupid calculation :|
                tickerItem.Width = mainWindow.Width / mainWindow.gameInfo.players.Count - ( mainWindow.gameInfo.players.Count == 2 ? 46 : (mainWindow.gameInfo.players.Count == 3 ? 34.5f : 23));
                positionFrames[i].Content = tickerItem;
                players.Add(tickerItem);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PausedFrame.Visibility = Visibility.Visible;
        }

        //TEMP METHOD (FOR GOING TO PODIUM
        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
