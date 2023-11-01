using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProjectGameInteraction2DRacingGame.OOP
{
    public class PlayerCar
    {
        public int ID;
        public double CarSpeed = 0;

        public Rectangle Car;
        public CarController controller = new CarController();

        public bool isBlockedForwards = false;
        public bool isBlockedBackwards = false;
        public DispatcherTimer carTimer = new DispatcherTimer();

        //Controls
        public Key Forward;
        public Key Backward;
        public Key Left;
        public Key Right;

        public bool isMovingForward = false;
        public bool isMovingBackward = false;

        public PlayerCar(int id, Rectangle car, int rot)
        {
            ID = id;
            Car = car;
            controller.carY = Canvas.GetTop(Car);
            controller.carX = Canvas.GetLeft(Car);
            controller.carRotation = rot;
            carTimer.Interval = TimeSpan.FromMilliseconds(15);
        }

        public void SetControls(List<Key> controls)
        {
            Forward = controls[0];
            Backward = controls[1];
            Left = controls[2];
            Right = controls[3];
        }

        public void PressButtonEvent(KeyEventArgs e, Key _Forward, Key Backward, Key Left, Key Right)
        {
            if (e.Key == _Forward)
            {
                isMovingForward = true;
                isMovingBackward = false;
            }
            if (e.Key == Backward)
            {
                isMovingForward = false;
                isMovingBackward = true;
            }
            if (e.Key == Left) 
            { 
                if (CarSpeed != 0) // Allow turning only when moving
                    controller.carRotation -= controller.turnSpeed;
            }
            if (e.Key == Right)
            {
                if (CarSpeed != 0) // Allow turning only when moving
                    controller.carRotation += controller.turnSpeed;
            }
            e.Handled = true;
        }
        public void ReleaseButtonEvent(KeyEventArgs e, Key Forward, Key Backward)
        {
            if (e.Key == Forward || e.Key == Backward)
            {
                isMovingForward = false;
                isMovingBackward = false;
            }
            e.Handled = true;
        }
    }
    public class CarController
    {
        public double carX = 100; // Initial car X position
        public double carY = 150; // Initial car Y position
        public double carRotation = 0; // Initial car rotation angle
        public double carSpeed = 0; // Car speed (starts at 0)
        public double carAcceleration = 0.05; // Acceleration rate
        public double topSpeed = 15; // Maximum speed
        public double bottomSpeed = 0.1; // Minimum speed to prevent stopping
        public double turnSpeed = 0.03; // Rotation speed
    }
}
