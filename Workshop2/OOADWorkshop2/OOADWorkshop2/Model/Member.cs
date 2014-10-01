using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADWorkshop2.Model
{
    class Member
    {
        private string _name;
        private string _id;
        private string _memberNr;

        private List<Boat> _boats;

        public Member(string name, string id, string memberNr, List<Boat> boats) { 
            _name = name;
            _id = id;
            _memberNr = memberNr;
            _boats = boats;
        }

        public Member getMember() {
            return this;
        }

        public string getCompactMember() {
            return _name + ", " + _memberNr + ", " + _boats.Count + " st båtar";
        }

        public string getExpandedMember() {
            string ret = _name + ", " + _id + ", " + _memberNr;

            for (int i = 0; i < _boats.Count; i++)
            {
                ret += "\n" +  _boats[i].getBoatInfo();
            }

            return ret;
        }

        
    }
}
