using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADWorkshop2.Model
{
    class Member
    {
        private string name;
        private string personalNumber;
        private int id;
        private List<Boat> boats;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string PersonalNumber
        {
            get { return personalNumber; }
            set { personalNumber = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        internal List<Boat> Boats
        {
            get { return boats; }
            set { boats = value; }
        }
        public Member(string name, string personalNumber, int id) 
        { 
            Name = name;
            PersonalNumber = personalNumber;
            Id = id;
            Boats = new List<Boat>();
        }
        public Member(string name, string personalNumber, int id, List<Boat> boats)
        {
            Name = name;
            PersonalNumber = personalNumber;
            Id = id;
            Boats = boats;
        }
    }
}
