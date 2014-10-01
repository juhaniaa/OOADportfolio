using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADWorkshop2.Model
{
    class Boat
    {
        private BoatType _boatType;
        private string _boatLength;
        public Boat(BoatType boatType, string boatLength) {
            _boatType = boatType;
            _boatLength = boatLength;
        }

        public string getBoatInfo() {
            return typeToString(_boatType) + ", " + _boatLength;
        }

        private string typeToString(BoatType boatType) {
            switch (boatType)
            {
                case BoatType.Sail:
                    return "Sailboat";
                
                case BoatType.MotorSail:
                    return "Motorsailer";
                    
                case BoatType.MotorBoat:
                    return "Motorboat";

                case BoatType.Canoe:
                    return "Kayak/Canoe";
                    
                case BoatType.Misc:
                    return "Misc";

                default: 
                    throw new ArgumentException();
            }
        }
    }
}
