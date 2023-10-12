using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for PlayerRaceTickerComponent.xaml
    /// </summary>
    public partial class PlayerRaceTickerComponent : Page
    {
        public PlayerRaceTickerComponent(Color color, int position, string playerName, int lap = 0)
        {
            InitializeComponent();
            SetColor(color);
            SetPosition(position);
            SetPlayerName(playerName);
            SetLap(lap);
        }

        public void SetColor(Color color)
        {
            PlayerColorDisplayer.Background = new SolidColorBrush(color);
        }
        public void SetPosition(int pos)
        {
            PositionDisplayer.Content = pos.ToString();
        }
        public void SetPlayerName(string Name)
        {
            PlayerNameDisplayer.Content = Name;
        }
        public void SetLap(int lap)
        {
            PlayerLapTotalDisplayer.Content = $"{lap}L";
        }
    }
}
