using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameInteraction2DRacingGame.OOP
{
    public class Session
    {
        // Variables
        private int SessionID;
        private int RaceLaps = 3;
        private int TrackID;
        int Category;
        //private SessionStatus Status;
        private TimeSpan Time;
        private List<Player> Players = new List<Player>();

        public Session()
        {
            //SetSessionID(SessionID);
            //SetLaps(Laps);
            //SetTrackID(TrackID);
            //SetTimeSpan(Time);
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }
        public List<Player> GetAllPlayers() => Players;
        public void ClearPlayerList()
        {
            Players.Clear();
        }

        public void SetCategory(int cat)
        {
            Category = cat;
        }
        public int GetCategory() => Category;

        public void IncreaseLaps()
        {
            RaceLaps++;
        }
        public void DecreaseLaps()
        {
            RaceLaps--;
        }
        public int GetRaceLaps() => RaceLaps;


        // Set Methods
        public void SetSessionID(int sessionID) { SessionID = sessionID; }
        public void SetTrackID(int trackID) { TrackID = trackID; }
        public void SetTimeSpan(TimeSpan time) { Time = time; }
        // Get Methods
        public int GetSessionID() => SessionID;
        public int GetTrackID() => TrackID;
        public TimeSpan GetTimeSpan() => Time;
    }
    public static class ListShuffle
    {
        //Randomize list for grid order :)
        public static void ShuffleMe<T>(this IList<T> list)
        {
            Random random = new Random();
            for (int i = list.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);
                T value = list[rnd];
                list[rnd] = list[i];
                list[i] = value;
            }
        }
    }
}
