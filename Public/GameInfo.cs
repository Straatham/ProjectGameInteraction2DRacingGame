using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameInteraction2DRacingGame.Public
{
    public class GameInfo
    {
        int Category;
        int raceLaps = 3;

        //TO DO (THOMAS) - Change string list to {Player} class list
        public List<string> players = new List<string>();

        public void SetCategory(int cat)
        {
            Category = cat;
        }
        public int GetCategory() => Category;

        public void IncreaseLaps()
        {
            raceLaps++;
        }
        public void DecreaseLaps()
        {  
            raceLaps--; 
        }
        public int GetRaceLaps() => raceLaps;


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
