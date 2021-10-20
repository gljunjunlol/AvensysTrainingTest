using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("We have the Requirements and necessary information:");
            Console.WriteLine("3 different type of users in the program: mainly customers, bank employees, bank managers");
            Console.WriteLine("customers with a loan and a savings account");
            Console.WriteLine("Employees to view customer info: ");
            Console.WriteLine("Bank Managers to view all customers + additional function: ");
            Console.WriteLine("");
            Console.WriteLine("________________________________");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|________________________________");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine();
            bool exit = false;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("*******************************");
                    Console.WriteLine(" << Bank Management System >> ");
    
                    Console.WriteLine("");
                    Console.WriteLine("1: Bank customers (Create new users)");
                    Console.WriteLine("");
                    Console.WriteLine("2: Bank Employee (Find customers / Employee Information ");
                    Console.WriteLine("");
                    Console.WriteLine("3: Bank Manager");
                    Console.WriteLine("");
                    Console.WriteLine("4: Exit the room");
                    Console.WriteLine("");
                    Console.WriteLine("*******************************");
                    Console.WriteLine("ENTER YOUR CHOICE:");

                    int input = Int32.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            {
                                CustomersManagement cgmt = new CustomersManagement();
                                Console.Clear();
                                cgmt.PerformOperation();
                                Console.WriteLine("1 : Savings");
                                Console.WriteLine("2 : Loan");
                                Console.WriteLine("3 : Go Back");
                                int choice = Int32.Parse(Console.ReadLine());

                                switch (choice)
                                {
                                    case 1:
                                        {
                                            Savings.performOperation();
                                            break;
                                        }
                                    case 2:
                                        {
                                            TakingLoan.performOperation();
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                                
                                break;
                            }
                        case 2:
                            {

                                BankEmployeesManagement bemgt = new BankEmployeesManagement();
                                Console.Clear();
                                bemgt.PerformOperation();
                                //SuperAdmin superadmin = new SuperAdmin();
                                //superadmin.PerformOperation();
                                break;
                            }
                        case 3:
                            {
                                BankManagersManagement bmmgt = new BankManagersManagement();
                                Console.Clear();
                                bmmgt.performOperationAdvanced();
                                bmmgt.PerformOperation();
                                
                                //Admin.TaskAssigned();
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
