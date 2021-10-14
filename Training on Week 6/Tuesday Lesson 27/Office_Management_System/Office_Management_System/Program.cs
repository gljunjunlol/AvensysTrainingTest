using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("Key in if you are the user");
                    Console.WriteLine("1: User");
                    Console.WriteLine("2: Superadmin (Create new users)");
                    Console.WriteLine("3: Admin");
                    Console.WriteLine("4: Exit the room");

                    int input = Int32.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            {
                                HandleAccountOpening.UserLogin();
                                break;
                            }
                        case 2:
                            {
                                SuperAdmin superadmin = new SuperAdmin();
                                superadmin.PerformOperation();
                                break;
                            }
                        case 3:
                            {
                                Admin.TaskAssigned();
                                break;
                            }
                        case 4:
                            {
                                exit = true;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                catch
                {

                }
                finally
                {

                }
                
            }
            Console.WriteLine("Exiting the program");
            
            

            Console.ReadLine();
        }
    }
}
