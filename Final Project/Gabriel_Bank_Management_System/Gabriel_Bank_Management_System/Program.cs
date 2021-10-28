using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public class Program
    {
        private readonly IConsoleIO ConsoleIO;

        public Program(IConsoleIO consoleIO)
        {
            ConsoleIO = consoleIO;
        }
        public Program()
        {
            ConsoleIO = new ConsoleIO();
        }
        static void Main(string[] args)
        {
            CustomersManagement cmgt = new CustomersManagement(); cmgt.References(); BankEmployeesManagement bemgt = new BankEmployeesManagement(); bemgt.References();
            HandleAccountOpeningEmployee emp = new HandleAccountOpeningEmployee(); 
            BankManagersManagement bmgt = new BankManagersManagement(); bmgt.References();
            HandleAccountOpeningBankManager mgr = new HandleAccountOpeningBankManager();

            List<int> loginTries = new List<int>();

            bool exit = false;
            while (!exit)
            {
                try
                {
                    ConsoleIO ConsoleIO = new ConsoleIO();
                    Program p = new Program();
                    p.Initialize();
                    
                    var action = ConsoleIO.ReadLine();

                    switch (action)
                    {
                        case "1":
                            {

                                Console.Clear();
                                cmgt.PerformOperation(cmgt, bemgt, bmgt, loginTries);
                                Console.WriteLine("1 : Savings" + "\n2 : Loan" + "\n3 : Go Back");
                                var choice = ConsoleIO.ReadLine();

                                switch (choice)
                                {
                                    case "1":
                                        {
                                            Savings saving = new Savings();
                                            saving.performOperation(cmgt);
                                            break;
                                        }
                                    case "2":
                                        {


                                            TakingLoan tk = new TakingLoan();
                                            tk.performOperation(cmgt, bemgt, bmgt);
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }

                                break;
                            }
                        case "2":
                            {

                                
                                Console.Clear();
                                bemgt.PerformOperation(cmgt, bemgt, bmgt);
                                Console.WriteLine("ok cleared");
                                Console.ReadLine();
                                break;
                            }
                        case "3":
                            {
                                Console.Clear();
                                bmgt.performOperationAdvanced(cmgt, bemgt, bmgt);
                                Console.WriteLine("ok seen manager");
                                Console.ReadLine();
                                break;
                            }
                        case "4":
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
                catch(Exception ex)
                {
                    Console.Write("Wrong Input. Please choose among the available options above:");
                    Console.ReadLine();
                }
                finally
                {

                }

            }
            Console.WriteLine("Exiting the program");
            Console.ReadLine();
        }
        public void Initialize()
        {
            ConsoleIO.WriteLine("We have the Requirements and necessary information:");
            ConsoleIO.WriteLine("3 different type of users in the program: mainly customers, bank employees, bank managers");
            ConsoleIO.WriteLine("customers with a loan and a savings account");
            ConsoleIO.WriteLine("Employees to view customer info: ");
            ConsoleIO.WriteLine("Bank Managers to view all customers + additional function: \n");
            ConsoleIO.WriteLine("________________________________");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|________________________________");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("|");
            ConsoleIO.WriteLine("");
            ConsoleIO.WriteLine("*******************************");
            ConsoleIO.WriteLine(" << Bank Management System >> \n");
            ConsoleIO.WriteLine("1: Bank customers (Create new users)\n");
            ConsoleIO.WriteLine("2: Bank Employee (Find customers / Employee Information\n ");
            ConsoleIO.WriteLine("3: Bank Manager\n");
            ConsoleIO.WriteLine("4: Exit the room\n");
            ConsoleIO.WriteLine("*******************************");
            ConsoleIO.WriteLine("ENTER YOUR CHOICE:");

        }
    }
}
