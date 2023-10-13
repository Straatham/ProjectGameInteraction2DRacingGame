using ProjectGameInteraction2DRacingGame.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectGameInteraction2DRacingGame.OOP
{
    public class Track
    {
        // Variables
        private int TrackID;
        private int Length;
        private int Difficulty;
        private string Name;
        private string ImageReference;
        private List<Circuit> _Track = new List<Circuit>();
        private TimeSpan PredictedLaptime;

        // Constructors
        public Track(int TrackID, int Length, int Difficulty, string Name, string ImageRef, TimeSpan PredictedLaptime)
        {
            SetTrackID(TrackID);
            SetLength(Length);
            SetDifficulty(Difficulty);
            SetName(Name);
            SetImageReference(ImageRef);
            SetTimeSpan(PredictedLaptime);
        }

        // Set Methods
        public void SetTrackID(int trackID) { TrackID = trackID; }
        public void SetLength(int length) { Length = length; }
        public void SetDifficulty(int difficulty) { Difficulty = difficulty; }
        public void SetName(string name) { Name = name; }
        public void SetImageReference(string image) 
        { 
            ImageReference = image; 
        }
        public void SetModel(List<Circuit> track) 
        {
            _Track = track; 
        }
        public void SetTimeSpan(TimeSpan predictedLaptime) { PredictedLaptime = predictedLaptime; }
        // Get Methods
        public int GetTrackID() => TrackID;
        public int GetLength() => Length;
        public int GetDifficulty() => Difficulty;
        public string GetName() => Name;
        public string GetImageReference() => ImageReference;
        public List<Circuit> GetCircuit() => _Track;
        public TimeSpan GetPredictedLaptime() => PredictedLaptime;

    }
}
