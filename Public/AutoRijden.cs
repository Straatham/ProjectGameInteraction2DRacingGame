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
