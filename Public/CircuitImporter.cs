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
                string[] split = File.ReadAllLines(file);
                foreach (string line in split)
                {
                    string[] split2 = line.Split(',');
                    string[] split3 = split2[0].Split(';');
                    CircuitList.Add(new Circuit(split3[0], split3[1], split2[1]));
                }
            }
            CircuitList = CircuitList.OrderBy(x => x.row).ThenBy(x => x.column).ToList();
        }
    }
    public class Circuit
    {
        public Circuit(string r, string c, string s)
        {
            row = int.Parse(r);
            column = int.Parse(c);
            surfaceType = (CircuitSurfaces)Enum.Parse(typeof(CircuitSurfaces), s);
        }
        public int row;
        public int column;
        public CircuitSurfaces surfaceType;
    }
    public enum CircuitSurfaces
    {
        Tarmac = 0,
        Grass = 1,
        Sand = 2,
        Wall = 3,    
    }
}
