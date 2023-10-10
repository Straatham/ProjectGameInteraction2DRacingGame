﻿using System;
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
}