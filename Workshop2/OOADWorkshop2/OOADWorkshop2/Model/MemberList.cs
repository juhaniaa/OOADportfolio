using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADWorkshop2.Model
{
    class MemberList
    {   
        private string textFileName = "memberList.txt";
        private MemberRepository _mRepository;
        private List<Member> _mList;

        // Konstruktor - fyll _mList med alla medlemmar från fil
        public MemberList() {
            _mRepository = new MemberRepository(textFileName);
            _mList = _mRepository.members;
        }

        public void register() { 
            
        }

        public List<Member> viewAll() {
            return _mList;
        }
    }
}
