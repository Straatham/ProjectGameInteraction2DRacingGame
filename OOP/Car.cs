using ProjectGameInteraction2DRacingGame.OOP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectGameInteraction2DRacingGame.OOP
{
    public class Car
    {
        // Variables
        private int CarID;
        private int ClassID;
        private int Mass;
        private float TopSpeed;
        private float Acceleration;
        private float Braking;
        private float Grip;
        private float Drag;
        private Color Color;
        private Image Image;
        // Constructors
        public Car(int CarID, int ClassID, int Mass, float TopSpeed, float Acceleration, float Braking, float Grip, float Drag, Color Color, Image Image)
        {
            SetCarID(CarID);
            SetClassID(ClassID);
            SetMass(Mass);
            SetTopSpeed(TopSpeed);
            SetAcceleration(Acceleration);
            SetBraking(Braking);
            SetGrip(Grip);
            SetDrag(Drag);
            SetColor(Color);
            SetImage(Image);
        }

        // Methods
        public void SetCarID(int carID)
        {
            CarID = carID;
        }
        public void SetClassID(int classID)
        {
            ClassID = classID;
        }
        public void SetMass(int mass)
        {
            Mass = mass;
        }
        public void SetTopSpeed(float setTopSpeed)
        {
            TopSpeed = setTopSpeed;
        }
        public void SetAcceleration(float setAcceleration)
        {
            Acceleration = setAcceleration;
        }
        public void SetBraking(float braking)
        {
            Braking = braking;
        }
        public void SetGrip(float grip)
        {
            Grip = grip;
        }
        public void SetDrag(float drag)
        {
            Drag = drag;
        }
        public void SetColor(Color color)
        {
            Color = color;
        }
        public void SetImage(Image image)
        {
            Image = image;
        }
        public int GetCarID() => CarID;
        public int GetClassID() => ClassID;
        public int GetMass() => Mass;
        public float GetTopSpeed() => TopSpeed;
        public float GetAcceleration() => Acceleration;
        public float GetBraking() => Braking;
        public float GetGrip() => Grip;
        public float GetDrag() => Drag;
        public Color GetColor() => Color; 
        public Image GetImage() => Image;

    }
}