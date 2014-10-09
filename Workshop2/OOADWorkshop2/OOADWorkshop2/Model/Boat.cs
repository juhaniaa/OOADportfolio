﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADWorkshop2.Model
{
    class Boat
    {
        private BoatType boatType;
        private string boatLength;

        public BoatType BoatType
        {
            get { return boatType; }
            set
            {
                boatType = value;
            }
        }

        public string BoatLength
        {
            get { return boatLength; }
            set { boatLength = value; }
        }

        public Boat(BoatType boatType, string boatLength) 
        {
            BoatType = boatType;
            BoatLength = boatLength;
        }

        public string getBoatInfo() {
            return typeToString(boatType) + ", " + boatLength;
        }

        private string typeToString(BoatType boatType) 
        {
            switch (boatType)
            {
                case BoatType.Sailboat:
                    return "Sailboat";
                
                case BoatType.Motorsail:
                    return "Motorsail";
                    
                case BoatType.Motorboat:
                    return "Motorboat";

                case BoatType.KayakCanoe:
                    return "Kayak/Canoe";
                    
                case BoatType.Misc:
                    return "Misc";

                default: 
                    throw new ArgumentException();
            }
        }
    }
}
