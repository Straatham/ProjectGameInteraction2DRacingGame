using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameInteraction2DRacingGame.OOP
{
    public class Session
    {
        // Variables
        private int SessionID;
        private int Laps;
        private int TrackID;
        //private SessionStatus Status;
        private TimeSpan Time;
        //private List<int> Players
        // Constructors
        public Session(int SessionID, int Laps, int TrackID, TimeSpan Time)
        {
            SetSessionID(SessionID);
            SetLaps(Laps);
            SetTrackID(TrackID);
            SetTimeSpan(Time);
        }
        // Set Methods
        public void SetSessionID(int sessionID) { SessionID = sessionID; }
        public void SetLaps(int laps) {  Laps = laps; }
        public void SetTrackID(int trackID) { TrackID = trackID; }
        public void SetTimeSpan(TimeSpan time) { Time = time; }
        // Get Methods
        public int GetSessionID() => SessionID;
        public int GetLaps() => Laps;
        public int GetTrackID() => TrackID;
        public TimeSpan GetTimeSpan() => Time;
    }
}
