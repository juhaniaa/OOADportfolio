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
        private MemberList ml;
        private ConsoleView cv;
        public void Start()
        {
            ml = new MemberList();
            cv = new ConsoleView(ml);
            MainMenu();
        }
        public void MainMenu()
        {
            
            cv.showMenu();
            var mc = cv.getMenuChoice();

            // Add new member
            if (mc == 1)
            {

                var name = cv.getMemberName();
                var personalNumber = cv.getMemberPersonalNumber();

                ml.register(name, personalNumber);
                MainMenu();
            }

            // Show all members in compact list
            else if (mc == 2)
            {
                cv.showCompact();
                showSpecificMember();
            }

            // Show all members in expanded list
            else if (mc == 3)
            {
                cv.showExpanded();
                showSpecificMember();
            }
            else
            { 
                MainMenu();
            }
        }

        public void showSpecificMember()
        {
            var id = cv.getMenuChoice();
            if (id == 0)
            {
                MainMenu();
            }
            else
            {
                try
                {
                    cv.showMemberWithMenu(id);
                    memberMenuAction(id);
                }
                catch
                {
                    MainMenu();
                }   
            }
        }

        public void memberMenuAction(int id)
        {
            
            var choice = cv.getMenuChoice();

            if (choice == 0)
            {
                MainMenu();
            }

            else if (choice == 1) // edit member
            {
                var name = cv.getMemberName();
                var personalNumber = cv.getMemberPersonalNumber();

                var oldBoatList = ml.getMemberById(id).Boats;
                ml.deleteMember(id);
                ml.register(name, personalNumber, oldBoatList, id);
                MainMenu();
            }
            else if (choice == 2) // delete member
            {
                ml.deleteMember(id);
                MainMenu();
            }
            else if (choice == 3) // show boats
            {
                cv.showBoats(id);
                showSpecificBoat(id);

            }
            else if (choice == 4) // add boat to member
            {
                int boatType = cv.getBoatType();
                string boatLength = cv.getBoatLength();
                ml.addBoatToMember(id, boatType, boatLength);
                MainMenu();
            }
        }

        public void showSpecificBoat(int id)
        {
            var choice = cv.getMenuChoice();
            if (choice == 0)
            {
                MainMenu();
            }
            else
            {
                cv.showBoatWithMenu(choice, id);
                boatMenuAction(id, choice);
            }
        }

        public void boatMenuAction(int id, int boatChoice)
        {
            
            var choice = cv.getMenuChoice();
            var boatIndex = boatChoice - 1;
            var oldBoatType = (int)ml.getMemberBoats(id)[boatIndex].BoatType + 1;
            var oldBoatLength = ml.getMemberBoats(id)[boatIndex].BoatLength;
            if (choice == 0)
            {
                MainMenu();
            }
            else if (choice == 1) // edit boat
            {
                int newBoatType = cv.getBoatType(oldBoatType);
                if (ml.userBoatTypeValid(newBoatType) == false)
                {
                    MainMenu();
                }
                string boatLength = cv.getBoatLength(oldBoatLength);
                ml.deleteBoatFromMember(id, boatIndex);
                ml.addBoatToMember(id, newBoatType, boatLength);
                MainMenu();
            }
            else if (choice == 2) // delete boat
            {
                ml.deleteBoatFromMember(id, boatIndex);
                MainMenu();
            }
        }
    }
}
