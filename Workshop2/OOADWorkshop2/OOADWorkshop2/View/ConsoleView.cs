using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOADWorkshop2.Model;

namespace OOADWorkshop2.View
{
    class ConsoleView
    {
        private MemberList _mList;

        public ConsoleView(MemberList mList) {
            _mList = mList;
        }
        
        public void showMenu() {
            Console.WriteLine("Boat Club");
            Console.WriteLine("1. Add member");
            Console.WriteLine("2. View compact list of members");
            Console.WriteLine("3. View expanded list of members");
            Console.WriteLine("4. View specific member");
            Console.Write("...");
        }

        public int getMenuChoice() {
        
            return int.Parse(Console.ReadLine());
        }

        public void showCompact() {

            Console.WriteLine("Members:");

            var compactList = _mList.viewAll();

            for (int i = 0; i < compactList.Count; i++) {
                Console.WriteLine(compactList[i].getCompactMember());
            }
        }

        public void showExpanded()
        {
            Console.WriteLine("Members:");

            var compactList = _mList.viewAll();

            for (int i = 0; i < compactList.Count; i++)
            {
                Console.WriteLine(compactList[i].getExpandedMember());
            }
        }

    }
}
