using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace OOADWorkshop2.Model
{
    class MemberRepository
    {
        private string name;
        private string personalNumber;
        private int id;
        public List<Member> members;

        private BoatType boatType;
        private string boatLength;        
        private List<Boat> boats;

        private string path = "memberList.txt";
        

        public MemberRepository() 
        {
            members = new List<Member>();
            if (!File.Exists(path)) {
                saveAllMembers(members); // if the file doesn't exist, create it by saving the empty members list
            }
        }

        public void LoadMembers() {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                MemberReadStatus status = MemberReadStatus.Indefinite;


                while ((line = reader.ReadLine()) != null)
                {
                    if (line == string.Empty)
                    {
                        continue;
                    }

                    // om line innehåller ett status meddelande
                    if (line == "[Name]")
                    {
                        status = MemberReadStatus.Name;
                    }

                    
                    else if (line == "[PersonalNumber]")
                    {
                        status = MemberReadStatus.PersonalNumber;
                    }

                    
                    else if (line == "[Id]")
                    {
                        status = MemberReadStatus.Id;
                    }

                    
                    else if (line == "[BoatType]")
                    {
                        status = MemberReadStatus.BoatType;
                    }

                    
                    else if (line == "[BoatLength]")
                    {
                        status = MemberReadStatus.BoatLength;
                    }

                    else if (line == "[End]")
                    {                 
                        members.Add(new Member(name, personalNumber, id, boats));
                    }

                    // line är ett namn, ett id, ett medlems nummer, en båttyp eller en båtlängd
                    else
                    {
                        // om medlemmens namn kommer på nästa rad
                        if (status == MemberReadStatus.Name)
                        {
                            name = line;
                            boats = new List<Boat>();
                        }

                        // om personnummer kommer på nästa rad
                        else if (status == MemberReadStatus.PersonalNumber)
                        {
                            personalNumber = line;
                        }

                        // om memdelmsid kommer på nästa rad
                        else if (status == MemberReadStatus.Id)
                        {
                            id = int.Parse(line);
                            
                        }

                         // om status är BoatType så...
                        else if (status == MemberReadStatus.BoatType)
                        {                           
                            boatType = (BoatType)Enum.Parse(typeof(BoatType), line);                
                        }

                         // om status är BoatLength så...
                        else if (status == MemberReadStatus.BoatLength)
                        {
                            boatLength = line;

                            boats.Add(new Boat(boatType, boatLength));
                        }
                    }
                }
            }
        }

        public void saveAllMembers(List<Member> members)
        {
         
            using (StreamWriter writer = new StreamWriter(path))
            {
                
                // varje Memeber i members
                for (int i = 0; i < members.Count; i++)
                {
                    Member memberToFile = members[i];       
        
                    writer.WriteLine("[Name]");
                    writer.WriteLine(memberToFile.Name);

                    writer.WriteLine("[PersonalNumber]");
                    writer.WriteLine(memberToFile.PersonalNumber);

                    writer.WriteLine("[Id]");
                    writer.WriteLine(memberToFile.Id);

                    if (memberToFile.Boats != null) { 

                        // varje Boat i nuvarande Member
                        foreach (Boat boatToFile in memberToFile.Boats)
                        {
                            writer.WriteLine("[BoatType]");
                            writer.WriteLine(boatToFile.BoatType);
                            writer.WriteLine("[BoatLength]");
                            writer.WriteLine(boatToFile.BoatLength);
                        }
                    }

                    writer.WriteLine("[End]");
                }
            }   
        }
    }
}
