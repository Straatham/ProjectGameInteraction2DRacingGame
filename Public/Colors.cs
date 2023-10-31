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
        public Color GetColorBlack() => (Color)ColorConverter.ConvertFromString("#1f1f1f");
        public Color GetColorGray() => (Color)ColorConverter.ConvertFromString("#b1b1b1");
        public Color GetColorDarkGray() => (Color)ColorConverter.ConvertFromString("#596275");
        public Color GetColorWhite() => (Color)ColorConverter.ConvertFromString("#efefef");
        public Color GetColorRed() => (Color)ColorConverter.ConvertFromString("#eb2f06");
        public Color GetColorLightRed() => (Color)ColorConverter.ConvertFromString("#ed4c67"); 
        public Color GetColorDarkRed() => (Color)ColorConverter.ConvertFromString("#b71540");
        public Color GetColorPink() => (Color)ColorConverter.ConvertFromString("#ed4c67");
        public Color GetColorDarkPink() => (Color)ColorConverter.ConvertFromString("#b71540");
        public Color GetColorPurple() => (Color)ColorConverter.ConvertFromString("#8854d0");
        public Color GetColorDarkPurple() => (Color)ColorConverter.ConvertFromString("#40407a");
        public Color GetColorLightBlue() => (Color)ColorConverter.ConvertFromString("#54a0ff");
        public Color GetColorBlue() => (Color)ColorConverter.ConvertFromString("#0652dd");
        public Color GetColorLightGreen() => (Color)ColorConverter.ConvertFromString("#14d727");
        public Color GetColorGreen() => (Color)ColorConverter.ConvertFromString("#009432");
        public Color GetColorOrange() => (Color)ColorConverter.ConvertFromString("#f79f1f");
        public Color GetColorLightYellow() => (Color)ColorConverter.ConvertFromString("#ffb34f");
        public Color GetColorYellow() => (Color)ColorConverter.ConvertFromString("#ffc312");
        public Color GetColorLightBrown() => (Color)ColorConverter.ConvertFromString("#cd6133");
        public Color GetColorBrown() => (Color)ColorConverter.ConvertFromString("#803110");

        public List<Color> GetAllColors() => new List<Color> { 
            GetColorBlack(),
            GetColorDarkGray(),
            GetColorGray(),
            GetColorWhite(), 
            GetColorRed(),
            GetColorLightRed(),
            GetColorDarkRed(),
            GetColorLightBrown(),
            GetColorBrown(),
            GetColorLightBlue(), 
            GetColorBlue(), 
            GetColorOrange(),
            GetColorLightYellow(),
            GetColorYellow(), 
            GetColorPink(),
            GetColorDarkPink(),
            GetColorPurple(),
            GetColorDarkPurple(),
            GetColorGreen(),
            GetColorLightGreen(),
        };
    }
}
