using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectGameInteraction2DRacingGame.Public
{
    public class Colors
    {
        public Color GetColorBlack() => Brushes.Black.Color;
        public Color GetColorGray() => Brushes.Gray.Color;
        public Color GetColorWhite() => Brushes.White.Color;
        public Color GetColorRed() => Brushes.Red.Color;
        public Color GetColorBlue() => Brushes.Black.Color;
        public Color GetColorOrange() => Brushes.Orange.Color;
        public Color GetColorYellow() => Brushes.Yellow.Color;
        public Color GetColorPink() => Brushes.Pink.Color;

        public List<Color> GetAllColors() => new List<Color> { 
            GetColorBlack(), 
            GetColorGray(), 
            GetColorWhite(), GetColorRed(), GetColorBlue(), GetColorOrange(), GetColorYellow(), GetColorPink() };
    }
}
