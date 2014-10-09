using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADWorkshop2.Model
{
    class MemberList
    {
        private MemberRepository mr;   
        private List<Member> ml;

        private MemberRepository Mr
        {
            get { return mr; }
            set { mr = value; }
        }

        private List<Member> Ml
        {
            get { return ml; }
            set { ml = value; }
        }

        // Konstruktor - fyll ml med alla medlemmar från fil
        public MemberList() 
        {
            Mr = new MemberRepository();
            Mr.LoadMembers();
            Ml = Mr.members;
        }

        public void register(string name, string personalNumber, List<Boat> oldBoatList = null, int oldId = 0) 
        {
            int id;

            if (oldId == 0)
            {
                if (Ml.Count > 0)
                {
                    id = Ml.Last<Member>().Id + 1;
                }
                else
                {
                    id = 1;
                }
            }

            else
            {
                id = oldId;
            }

            var m = new Member(name, personalNumber, id);
            Ml.Add(m);

            if (oldBoatList != null)
            {
                foreach (Boat boat in oldBoatList)
                {
                    addBoatToMember(id, (int)boat.BoatType, boat.BoatLength);
                }
            }

            Mr.saveAllMembers(Ml);
        }

        public List<Member> viewAll() 
        {
            return Ml;
        }

        public Member getMemberById(int id)
        {
            for (var i = 0; i < Ml.Count; i++)
            {
                if (id == Ml[i].Id)
                {
                    return Ml[i];
                }
            }
            return null;
        }

        public List<Boat> getMemberBoats(int memberId)
        {
            Member m = getMemberById(memberId);

            return m.Boats;
        }

        public void addBoatToMember(int id, int boatType, string boatLength)
        {
            var bl = getMemberById(id).Boats;
            
            BoatType bt = (BoatType)boatType;
            bl.Add(new Boat(bt, boatLength));
            Mr.saveAllMembers(Ml);
        }

        public void deleteBoatFromMember(int id, int boatIndex)
        {
            var bl = getMemberById(id).Boats;
            bl.RemoveAt(boatIndex);
            Mr.saveAllMembers(Ml);
        }

        public void deleteMember(int id)
        {
            var m = getMemberById(id);
            Ml.Remove(m);
            Mr.saveAllMembers(Ml);
        }

        public bool userBoatTypeValid(int newBoatType)
        {
            if (newBoatType > (int)BoatType.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
