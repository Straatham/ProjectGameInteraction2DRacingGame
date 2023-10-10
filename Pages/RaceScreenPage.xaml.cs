using ProjectGameInteraction2DRacingGame.Components;
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

            positionFrames.Add(Position_1);
            positionFrames.Add(Position_2);
            positionFrames.Add(Position_3);
            positionFrames.Add(Position_4);
            DisplayPlayers();
        }

        void DisplayPlayers()
        {
            for (int i = 0; i < 4; i++)
            {
                PlayerRaceTickerComponent tickerItem = new PlayerRaceTickerComponent(Brushes.White.Color, i, $"Player {i + 1}");
                tickerItem.Width = mainWindow.Width / 4 - 23;
                positionFrames[i].Content = tickerItem;
                players.Add(tickerItem);
            }
        }
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
