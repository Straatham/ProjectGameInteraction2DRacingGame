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
        public static List<CarClass> ImportTracks()
        {
            List<CarClass> list = new List<CarClass>();

            if(File.Exists(@"OOPTextFiles\CarClasses.txt"))
            {
                foreach (string file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\GameInfo\", "*.txt*", SearchOption.AllDirectories))
                {
                    string[] split = File.ReadAllLines(file);
                    foreach (string line in split)
                    {
                        string[] split2 = line.Split(',');
                        string[] split3 = split2[0].Split(';');
                        list.Add(new CarClass(int.Parse(split3[0]), split3[1]));
                    }
                }
                return list;
            }
            throw new Exception();
        }
    }
}
