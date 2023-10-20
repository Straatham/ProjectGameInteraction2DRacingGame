using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ProjectGameInteraction2DRacingGame.Public
{
    public class AutoRijden
    {
       public bool moveUp1, moveDown1, moveLeft1, moveRight1; // Player 1
       public bool moveUp2, moveDown2, moveLeft2, moveRight2; // Player 2
       public bool moveUp3, moveDown3, moveLeft3, moveRight3; // Player 3
       public bool moveUp4, moveDown4, moveLeft4, moveRight4; // Player 4
        public void KnopIngedrukt(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W) moveUp1 = true; // Player 1
            if (e.Key == Key.S) moveDown1 = true;
            if (e.Key == Key.A) moveLeft1 = true;
            if (e.Key == Key.D) moveRight1 = true;
            if (e.Key == Key.Up) moveUp2 = true; // Player 2
            if (e.Key == Key.Down) moveDown2 = true;
            if (e.Key == Key.Left) moveLeft2 = true;
            if (e.Key == Key.Right) moveRight2 = true;
            if (e.Key == Key.I) moveUp3 = true; // Player 3
            if (e.Key == Key.K) moveDown3 = true;
            if (e.Key == Key.J) moveLeft3 = true;
            if (e.Key == Key.L) moveRight3 = true;
            if (e.Key == Key.NumPad8) moveUp4 = true; // Player 4
            if (e.Key == Key.NumPad5) moveDown4 = true;
            if (e.Key == Key.NumPad4) moveLeft4 = true;
            if (e.Key == Key.NumPad6) moveRight4 = true;
        }

        public void KnopLos(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W) moveUp1 = false; // Player 1
            if (e.Key == Key.S) moveDown1 = false;
            if (e.Key == Key.A) moveLeft1 = false;
            if (e.Key == Key.D) moveRight1 = false;
            if (e.Key == Key.Up) moveUp2 = false; // Player 2
            if (e.Key == Key.Down) moveDown2 = false;
            if (e.Key == Key.Left) moveLeft2 = false;
            if (e.Key == Key.Right) moveRight2 = false;
            if (e.Key == Key.I) moveUp3 = false; // Player 3
            if (e.Key == Key.K) moveDown3 = false;
            if (e.Key == Key.J) moveLeft3 = false;
            if (e.Key == Key.L) moveRight3 = false;
            if (e.Key == Key.NumPad8) moveUp4 = false; // Player 4
            if (e.Key == Key.NumPad5) moveDown4 = false;
            if (e.Key == Key.NumPad4) moveLeft4 = false;
            if (e.Key == Key.NumPad6) moveRight4 = false;
        }
        public Rectangle car;

        public AutoRijden()
        {
            car = CreateNewCar();
            
        }
       

        public Rectangle CreateNewCar()
        {
            return new Rectangle
            {
                Name = "Car",
                Width = 50,
                Height = 50,
                Fill = Brushes.HotPink
                
            };

        }



    }
}
