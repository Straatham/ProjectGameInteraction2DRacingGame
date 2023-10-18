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

        public bool moveUp, moveDown, moveLeft, moveRight;
        public float topSpeed;
        public Rectangle car;

        public AutoRijden()
        {
            car = CreateNewCar();
            
        }
       

        public void AutoMovementChecken(object sender, EventArgs e)
        {
            if (moveUp)
                Canvas.SetTop(car, Canvas.GetTop(car) - 10);
            if (moveDown)
                Canvas.SetTop(car, Canvas.GetTop(car) + 10);
            if (moveLeft)
                Canvas.SetLeft(car, Canvas.GetLeft(car) - 10);
            if (moveRight)
                Canvas.SetLeft(car, Canvas.GetLeft(car) + 10);
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
