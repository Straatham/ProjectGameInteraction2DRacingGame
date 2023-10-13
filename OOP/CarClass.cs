using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameInteraction2DRacingGame.OOP
{
    public class CarClass
    {
        // Variables
        private int ClassID;
        private string Name;
        // Constructors
        public CarClass(int ClassID, string Name)
        {
            SetClassID(ClassID);
            SetName(Name);
        }
        // Set Methods
        public void SetClassID(int classID) { ClassID = classID; }
        public void SetName(string name) {  Name = name; }
        // Get Methods
        public int GetClassID() => ClassID;
        public string GetName() => Name;
    }
}
