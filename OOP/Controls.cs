using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGameInteraction2DRacingGame.OOP
{
    public class Controls
    {
        // Variables
        private int ControlsID;
        // Constructors
        public Controls(int ControlsID)
        {
            SetControlsID(ControlsID);
        }
        // Set Methods
        public void SetControlsID(int controlsID) { ControlsID = controlsID; }
        // Get Methods
        public int GetControlsID() => ControlsID;
    }
}
