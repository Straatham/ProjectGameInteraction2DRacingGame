using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectGameInteraction2DRacingGame.Public
{
    public  class CircuitImporter
    {
        public List<Circuit> CircuitList = new List<Circuit>();
        public void ImportTracks()
        {
            foreach (string file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\Circuits\", "*.txt*", SearchOption.AllDirectories))
            {
                //Init the circuit
                Circuit circuit = new Circuit(Path.GetFileNameWithoutExtension(file));

                //Split all lines
                string[] split = File.ReadAllLines(file);

                //Get the first line that includes the positions of the track
                string[] posSplit =  split[0].Split('/');

                foreach (string pos in posSplit)
                {
                    //Add position to circuit
                    string[] split2 = pos.Split(';');
                    circuit.AddTrackPositions(new TrackPosition(split2[0], split2[1], split2[2]));
                }

                foreach (string line in split.Skip(1))
                {
                    string[] split2 = line.Split(',');
                    string[] split3 = split2[0].Split(';');
                    circuit.AddPartToTrack(new TrackPart(split3[0], split3[1], split2[1]));
                }
                CircuitList.Add(circuit);
            }

            //Sort the rows and then columns
            for (int i = 0; i < CircuitList.Count; i++)
                CircuitList[i].Track = CircuitList[i].Track.OrderBy(x => x.row).ThenBy(x => x.column).ToList();
        }
    }
    public class Circuit
    {

        public string reference;
        public List<TrackPart> Track = new List<TrackPart>();
        public List<TrackPosition> spawnPositions = new List<TrackPosition>();

        public Circuit(string _ref)
        {
            reference = _ref;            
        }
        public void AddPartToTrack(TrackPart part) 
        {
            Track.Add(part); 
        }
        public void AddTrackPositions(TrackPosition pos)
        {
            spawnPositions.Add(pos);
        }
    }
    public class TrackPart
    {
        public int row;
        public int column;
        public CircuitSurfaces surfaceType;
        public TrackPart(string r, string c, string s)
        {
            row = int.Parse(r);
            column = int.Parse(c);
            surfaceType = (CircuitSurfaces)int.Parse(s);
        }
    }

    public class TrackPosition
    {
        public int X;
        public int Y;
        public int Rotation;
        public TrackPosition(string x, string y, string rot)
        {
            X = int.Parse(x);
            Y = int.Parse(y);
            Rotation = int.Parse(rot);
        }
    }
    public enum CircuitSurfaces
    {
        Tarmac = 0,
        Grass = 1,
        Sand = 2,
        Wall = 3,
        finishline = 4,
        checkpoint = 5,
        asphalt2 = 6,
        dirt = 7,   
    }
}
