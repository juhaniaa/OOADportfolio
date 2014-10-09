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

        public Member getMember() 
        {
            return this;
        }

        public string getCompactMember() 
        {
            return String.Format("{0}, #{1}, {2} st båtar.", name, id, boats.Count);
        }

        public string getExpandedMember() 
        {
            var ret = String.Format("{0}, #{1}, Personal Nr: {2}", name, id, personalNumber);

            for (int i = 0; i < boats.Count; i++)
            {
                ret = String.Format("{0}\n     {1}. {2}", ret, i + 1, boats[i].getBoatInfo());
            }

            return ret;
        }

        public int getMemberId()
        {
            return Id;
        }
    }
}
