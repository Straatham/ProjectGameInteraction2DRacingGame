using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectGameInteraction2DRacingGame.Public
{
    public class GameSettingsImporter
    {
        static string path = AppDomain.CurrentDomain.BaseDirectory + @"\Settings\" + @"GameSettings.txt";
        public static void ReadFromFile()
        {
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\Settings\");
                File.Create(path);
            }
            else //Empty file!!! Fails if exists!
            {
                string[] bob = File.ReadAllLines(path);
                GameSettings.SetMusicVolume(float.Parse(bob[0]));
                GameSettings.SetCarVolume(float.Parse(bob[1]));
                GameSettings.SetEffectsVolume(float.Parse(bob[2]));
                GameSettings.SetTranslation(int.Parse(bob[3]));
            }    
        }
        public static void WriteToFile()
        {
            if (!File.Exists(path))
                File.Create(path);            

            TextWriter txt = new StreamWriter(path);
            txt.WriteLine(GameSettings.GetMusicVolume());
            txt.WriteLine(GameSettings.GetCarVolume());
            txt.WriteLine(GameSettings.GetEffectsVolume());
            txt.WriteLine(GameSettings.GetTranslation());
            txt.Close();
        }
    }
}
