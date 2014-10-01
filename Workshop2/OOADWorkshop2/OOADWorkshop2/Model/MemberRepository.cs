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
        private string id;
        private string memberNr;
        public List<Member> members;

        private BoatType boatType;
        private string boatLength;        
        private List<Boat> boats;
        

        public MemberRepository(string path) {

            members = new List<Member>();
           

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

                    
                    if (line == "[Name]")
                    {
                        status = MemberReadStatus.Name;
                    }

                    
                    else if (line == "[Id]")
                    {
                        status = MemberReadStatus.Id;
                    }

                    
                    else if (line == "[MemberNr]")
                    {
                        status = MemberReadStatus.MemberNr;
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
                        members.Add(new Member(name, id, memberNr, boats));
                    }

                    // line är ett namn, ett id, ett medlems nummer, en båttyp eller en båtlängd
                    else
                    {
                      
                        if (status == MemberReadStatus.Name)
                        {
                            name = line;
                            boats = new List<Boat>();
                        }

                        // om status är Id
                        else if (status == MemberReadStatus.Id)
                        {
                            id = line;
                        }

                        // om status är Member så...
                        else if (status == MemberReadStatus.MemberNr)
                        {
                            memberNr = line;
                            
                        }

                         // om status är BoatType så...
                        else if (status == MemberReadStatus.BoatType)
                        {
                            switch(line){
                                case "Sailboat":
                                    boatType = BoatType.Sail;
                                    break;
                                case "Motorsailer":
                                    boatType = BoatType.MotorSail;
                                    break;
                                case "Motorboat":
                                    boatType = BoatType.MotorBoat;
                                    break;
                                case "Kayak/Canoe":
                                    boatType = BoatType.Canoe;
                                    break;
                                case "Misc":
                                    boatType = BoatType.Misc;
                                    break;

                                default:
                                    throw new ArgumentException();
                            }
                              
                            
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
    }
}
