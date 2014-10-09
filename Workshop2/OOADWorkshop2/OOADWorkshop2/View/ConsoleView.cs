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
        private MemberList _ml;

        internal MemberList Ml
        {
            get { return _ml; }
            set { _ml = value; }
        }

        public ConsoleView(MemberList ml)
        {
            Ml = ml;
        }
        
        public void showMenu() 
        {
            writeHeader("Boat Club Menu");
            Console.WriteLine("1. Add member");
            Console.WriteLine("2. View compact list of members");
            Console.WriteLine("3. View expanded list of members");
        }

        public int getMenuChoice(int initial = 0)
        {
            if (initial == 0) // if no initial value is sent
            {             
                string ret = Console.ReadLine();

                try
                {
                    return int.Parse(ret);
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("Hit enter to keep the boat type or backspace to enter a new one.");
                Console.Write(initial);
              
                var userAction = Console.ReadKey();
                while ((userAction.Key != ConsoleKey.Enter) && (userAction.Key != ConsoleKey.Backspace))
                {
                    Console.CursorLeft -= 1;
                    Console.Write(" ");
                    Console.CursorLeft -= 1;
                    userAction = Console.ReadKey();
                    
                }

                if (userAction.Key == ConsoleKey.Backspace)
                {
                    Console.Write(" ");
                    Console.CursorLeft -= 1;
                    initial = int.Parse(Console.ReadLine());
                }

                return initial;     
            }
        }

        public string getInput() 
        {
            return Console.ReadLine();
        }

        public string getMemberName() 
        {
            writeHeader("Input Name");
            return getInput();
        }

        public string getMemberPersonalNumber()
        {
            writeHeader("Input Personal Number");           
            return getInput();
        }

        public void showCompact() 
        {
            writeHeader("Members Menu");
            var compactList = _ml.viewAll();

            for (int i = 0; i < compactList.Count; i++) {
                Console.Write(compactList[i].Id + ". ");
                Console.WriteLine(compactList[i].getCompactMember());
            }
            writeFooter("0. Go back to main menu");
        }

        public void showExpanded()
        {
            writeHeader("Expanded Members Menu:");
            var compactList = _ml.viewAll();
            for (int i = 0; i < compactList.Count; i++)
            {
                Console.Write(compactList[i].Id + ". ");
                showMember(compactList[i].Id);
            }
            writeFooter("0. Go back to main menu");
        }

        public void showMemberWithMenu(int id)
        {
            writeHeader("Member Menu:");
            showMember(id);
            showCrudMenu();
            Console.WriteLine("3. Manage boats");
            Console.WriteLine("4. Add boat");
            writeFooter("0. Go back to main menu");
        }

        public void showMember(int id) 
        {
            var m = _ml.getMemberById(id);
            Console.WriteLine(m.getExpandedMember());
        }

        public void showCrudMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Edit");
            Console.WriteLine("2. Delete");
        }

        public void chooseMember() 
        {
            Console.WriteLine();
            Console.WriteLine("ChooseMember:");
        }

        public void writeHeader(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine();
        }

        public void writeFooter(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
        }

        public void showBoats(int id) 
        {
            writeHeader("Member boats");

            List<Boat> boats = _ml.getMemberBoats(id);

            for (int i = 0; i < boats.Count; i++)
            {
                Console.Write((i + 1) + ". ");
                Console.WriteLine(boats[i].getBoatInfo());
            }
            writeFooter("0. Go back to main menu");

        }

        public void showBoatWithMenu(int boatIndex, int id)
        {
            writeHeader("Boat menu");
            List<Boat> boats = _ml.getMemberBoats(id);
            Console.WriteLine(boats[boatIndex - 1].getBoatInfo());
            
            showCrudMenu();
            writeFooter("0. Go back to main menu");
        }

        public int getBoatType(int boatType = 0)
        {
            writeHeader("Choose boat type");    
            Console.WriteLine("1. Sailboat");
            Console.WriteLine("2. Motorsail");
            Console.WriteLine("3. Motorboat");
            Console.WriteLine("4. Kayak/Canoe");
            Console.WriteLine("5. Misc");
            return getMenuChoice(boatType) - 1;
        }

        public string getBoatLength(string boatLength = null)
        {
            writeHeader("Input boat length");
            if (boatLength == null)
            {
                return getInput();
            }
            return getNewValue(boatLength);
        }

        public string getNewValue(string oldValue)
        {
            Console.Write(oldValue);
            var userAction = Console.ReadKey();
            while ((userAction.Key != ConsoleKey.Enter) && (userAction.Key != ConsoleKey.Backspace))
            {
                Console.CursorLeft -= 1;
                Console.Write(" ");
                Console.CursorLeft -= 1;
                userAction = Console.ReadKey();
            }

            if (userAction.Key == ConsoleKey.Backspace)
            {
                for (int i = 0; i < oldValue.Length; i++)
                {
                    if (i > 0)
                    {
                        Console.CursorLeft -= 1;
                    }
                    Console.Write(" ");
                    Console.CursorLeft -= 1;
                }
                oldValue = Console.ReadLine();
            }

            return oldValue;
        }
    }
}
