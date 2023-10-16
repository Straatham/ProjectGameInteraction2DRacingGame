using ProjectGameInteraction2DRacingGame.OOP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameInteraction2DRacingGame.Public
{
    public class OOPClassesImporter
    {
        public static List<CarClass> ImportClasses()
        {
            List<CarClass> list = new List<CarClass>();

            if (File.Exists(@AppDomain.CurrentDomain.BaseDirectory + @"\GameData\" + "CarClasses.txt"))
            {
                foreach (string file in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\GameData\" + "CarClasses.txt").Skip(1))
                {
                    string[] split2 = file.Split(',');
                    list.Add(new CarClass(int.Parse(split2[0]), split2[1]));
                    
                }
                return list;
            }
            throw new Exception();
        }
        public static List<Track> ImportTracks()
        {
            List<Track> list = new List<Track>();

            if (File.Exists(@AppDomain.CurrentDomain.BaseDirectory + @"\GameData\" + "Tracks.txt"))
            {
                foreach (string file in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\GameData\" + "Tracks.txt").Skip(1))
                {
                    string[] split2 = file.Split(',');
                    list.Add(new Track(int.Parse(split2[0]), int.Parse(split2[1]), int.Parse(split2[2]), split2[3], split2[4], TimeSpan.Parse(split2[5])));
                }
                return list;
            }
            throw new Exception();
        }
    }
}
