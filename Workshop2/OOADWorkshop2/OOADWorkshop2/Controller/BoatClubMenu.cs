using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOADWorkshop2.Model;
using OOADWorkshop2.View;

namespace OOADWorkshop2.Controller
{
    class BoatClubMenu
    {
        public void Start(){
            var ml = new MemberList();
            var cv = new ConsoleView(ml);

            cv.showMenu();
            var mc = cv.getMenuChoice();

            if (mc == 1) {
                ml.register();

            } else if (mc == 2) {
                cv.showCompact();
                Console.Read();

            } else if (mc == 3) {
                cv.showExpanded();
                Console.Read();
            }
        }

    }
}
