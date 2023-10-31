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
        public List<List<Circuit>> CircuitList = new List<List<Circuit>>();
        public void ImportTracks()
        {
            foreach (string file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\Circuits\", "*.txt*", SearchOption.AllDirectories))
            {
                string[] split = File.ReadAllLines(file);
                List<Circuit> pieces = new List<Circuit>();
                foreach (string line in split)
                {
                    string[] split2 = line.Split(',');
                    string[] split3 = split2[0].Split(';');
                    pieces.Add(new Circuit(Path.GetFileNameWithoutExtension(file), split3[0], split3[1], split2[1]));
                }
                CircuitList.Add(pieces);
            }
            for (int i = 0; i < CircuitList.Count; i++)
                CircuitList[i] = CircuitList[i].OrderBy(x => x.row).ThenBy(x => x.column).ToList();
        }
    }
    public class Circuit
    {
        public string reference;
        public int row;
        public int column;
        public CircuitSurfaces surfaceType;
        public Circuit(string _ref, string r, string c, string s)
        {
            reference = _ref;
            row = int.Parse(r);
            column = int.Parse(c);
            surfaceType = (CircuitSurfaces)Enum.Parse(typeof(CircuitSurfaces), s);
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
