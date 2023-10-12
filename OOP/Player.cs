using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectGameInteraction2DRacingGame.OOP
{
    public class Player
    {
        // Variables
        private int PlayerID;
        private int CarID;
        private int ClassID;
        private int PlayersControlID;
        private string PlayerName;
        //private Enum PlayerStatus;
        private Brushes Color;
        // Constructors
        public Player(int PlayerID, int CarID, int ClassID, int PlayersControlID, string PlayerName, Enum PlayerStatus, Brushes Color) 
            {
            SetPlayerID(PlayerID);
            SetCarID(CarID);
            SetClassID(ClassID);
            SetPlayersControlID(PlayersControlID);
            SetPlayerName(PlayerName);
            //SetPlayerStatus(PlayerStatus);
            SetColor(Color);
            }
        // Set Methods
        public void SetPlayerID(int playerID) { PlayerID = playerID; }
        public void SetCarID(int carID) { CarID = carID; }
        public void SetClassID(int classID) { ClassID = classID; }
        public void SetPlayersControlID(int playersControlID) { PlayersControlID = playersControlID; }
        public void SetPlayerName(string playerName) { PlayerName = playerName; }
        //public void SetPlayerStatus(Enum playerStatus) { PlayerStatus = playerStatus; } 
        public void SetColor(Brushes color) {  Color = color; }

        // Get Methods
        public int GetPlayerID() => PlayerID;
        public int GetCarID() => CarID;
        public int GetClassID() => ClassID;
        public int SetPlayersControlID() => PlayersControlID;
        public string SetPlayerName() => PlayerName;
        public Brushes SetColor() => Color;
    }
}
