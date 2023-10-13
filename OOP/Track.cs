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
        private Object Walls;
        private Image Image;
        private Image Model;
        private TimeSpan PredictedLaptime;

        // Constructors
        public Track(int TrackID, int Length, int Difficulty, string Name, Object Walls, Image Image, Image Model, TimeSpan PredictedLaptime)
        {
            SetTrackID(TrackID);
            SetLength(Length);
            SetDifficulty(Difficulty);
            SetName(Name);
            SetWalls(Walls);
            SetImage(Image);
            SetModel(Model);
            SetTimeSpan(PredictedLaptime);
        }

        // Set Methods
        public void SetTrackID(int trackID) { TrackID = trackID; }
        public void SetLength(int length) { Length = length; }
        public void SetDifficulty(int difficulty) { Difficulty = difficulty; }
        public void SetName(string name) { Name = name; }
        public void SetWalls(Object walls) { Walls = walls; }
        public void SetImage(Image image) { Image = image; }
        public void SetModel(Image model) { Model = model; }
        public void SetTimeSpan(TimeSpan predictedLaptime) { PredictedLaptime = predictedLaptime; }
        // Get Methods
        public int GetTrackID() => TrackID;
        public int GetLength() => Length;
        public int GetDifficulty() => Difficulty;
        public string GetName() => Name;
        public Object GetWalls() => Walls;
        public Image GetImage() => Image;
        public Image GetModel() => Model;
        public TimeSpan GetPredictedLaptime() => PredictedLaptime;

    }
}
