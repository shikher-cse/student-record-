using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newstudentrecord_app
{    public class student
    {   public string name       { get; set; }
        public string department { get; set; }
        public string sex        { get; set; }
        public long   rollnumber { get; set; }
        public long  phonenumber { get; set; }
    }
    public class Program
    {   public static List<student> mystudent = new List<student>(); // making the list global     
        public static  void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;   
            Console.WriteLine("___________Student's Record_____________");
            Console.ResetColor();
            try
            {   displaymenu();
                int yourchoice;
                string confirm;
                do
                {
                    Console.Write("Enter the choice :-             ");
                    yourchoice = Convert.ToInt32(Console.ReadLine());                    
                    switch (yourchoice)
                    {   case 1:    Add();  break;
                        case 2: delete();  break;
                        case 3: update();  break;
                        case 4: viewall(); break;
                        default: Console.WriteLine(" !! Please Enter the right choice !! "); break;
                    }
                    Console.WriteLine();
                    
                    Console.Write("press  Y to  continue:          ");
                    confirm = Console.ReadLine().ToString().ToUpper();                    
                } while (confirm == "Y");
            }
            catch (   FormatException  )
            {   Console.WriteLine("Invalid input");
                Console.ReadLine();                          
            }           
        }
                public static void displaymenu()
                {                         
                    Console.WriteLine(" please choose a relevant choice from the menu :-  ");
                    Console.WriteLine("____________________________________________________");
                    Console.WriteLine();
                    Console.WriteLine("1. Add student's  record     :-             ");
                    Console.WriteLine("2. Delete student's record   :-             ");
                    Console.WriteLine("3. Update student's record   :-             ");
                    Console.WriteLine("4. View all student's record :-             ");
                }  
                public static void Add()
                {   student objstudent = new student();                          
                    Console.Write("Enter student's Name:                 ");
                    objstudent.name = Console.ReadLine().ToString();                                  
                    Console.Write("Enter student's Department:-          ");
                    objstudent.department = Console.ReadLine().ToString();                    
                    truf:
                    Console.Write("Enter student's Sex (F or M):         ");
                    objstudent.sex = Console.ReadLine().ToString().ToUpper();               
                    if (objstudent.sex == "M")
                    { goto trim; }
                    else if (objstudent.sex == "F")
                    { goto trim; }
                    else
                    {   Console.WriteLine("Please enter a relevant  choice among{M /F} ");
                        goto truf;
                    }               
                    trim:
                    Console.Write("Enter student's roll NUMBER :-        ");
                    objstudent.rollnumber = long.Parse(Console.ReadLine());                    
                    Console.Write("Enter student's phone number  :-      ");
                    objstudent.phonenumber = long.Parse(Console.ReadLine());                   
                    mystudent.Add(objstudent);
                }                             
                public static void viewall()
                {
                    Console.WriteLine("|   {0,-20}{1,-10}{2,-10}{3,-20}{4,-20}", "0", "1", "2", "3", "4");
                    Console.WriteLine("|   {0,-20} {1,-10}{2,-10}{3,-20}{4,-20}", "NAME", "DEPT.", "SEX", "rollno.", "phoneno");
                    Console.WriteLine("====================================================================================");             
                    //obj.name console.readLine where error handleing                                                     
                    foreach (var objstudent  in  mystudent)
                    {   Console.WriteLine("|    {0,-20}{1,-10}{2,-10}{3,-20}{4,-20} ", objstudent.name, objstudent.department, objstudent.sex, objstudent.rollnumber,
                        objstudent.phonenumber);                      
                    }  
                       Console.ReadLine();               
                }               
                public static  void  delete()
                {   Console.WriteLine(" please enter the roll number that you want to delete :- ");
                    long rolldel = long.Parse(Console.ReadLine());                    
                    student objstudent = mystudent.Where(x => x.rollnumber == rolldel).FirstOrDefault();
                    {   mystudent.Remove(objstudent);
                        Console.WriteLine(" the record has been deleted  successfully !! ");              
                    }       
                }
                public  static  void  update()
                {   Console.WriteLine("please enter the roll number whose enteries you want to update :-");
                    long rolldel = long.Parse(Console.ReadLine());
                    student objstudent = mystudent.Where(x => x.rollnumber == rolldel).FirstOrDefault();
                    {   Console.WriteLine(" roll number found ,  please enter the new enteries :- ");
                        Console.WriteLine("_________________________________________________________");
                        Console.Write("Enter student's Name:                 ");
                        objstudent.name = Console.ReadLine().ToString();
                        //mystudent.Add(objstudent.name);

                        Console.Write("Enter student's Department:-          ");
                        objstudent.department = Console.ReadLine().ToString();
                        //mystudept.Add(dept);
                        truf:
                        Console.Write("Enter student's Sex (F or M):         ");
                        objstudent.sex = Console.ReadLine().ToString().ToUpper();
                        // mystusex.Add(sex);
                        if (objstudent.sex == "M")
                        { goto trim; }
                        else if (objstudent.sex == "F")
                        { goto trim; }
                        else
                        {   Console.WriteLine("Please enter a relevant  choice anong{M /F} ");
                            goto truf;
                        }
                         trim:
                         objstudent.rollnumber =   rolldel;                      
                        Console.Write("Enter student's phone number  :-      ");
                        objstudent.phonenumber = long.Parse(Console.ReadLine());
                    }

                }           
    }
}