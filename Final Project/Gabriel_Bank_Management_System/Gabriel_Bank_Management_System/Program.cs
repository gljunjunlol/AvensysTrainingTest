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
            CustomerAccountManager cam = new CustomerAccountManager(); cam.References(); EmployeeAccountManager eam = new EmployeeAccountManager(); eam.References(); EmployeeAccountManager emp = new EmployeeAccountManager(); ManagerAccountManager mam = new ManagerAccountManager(); mam.References(); ManagerAccountManager mgr = new ManagerAccountManager();
            CustomersManager cam1 = new CustomersManager(); BankEmployeesManager eam1 = new BankEmployeesManager();
            BankManagersManager mam1 = new BankManagersManager();


            List<int> loginTries = new List<int>(); Program p = new Program(); ConsoleIO ConsoleIO = new ConsoleIO(); bool exit = false;



            while (!exit)
            {
                try
                {
                    p.performOperation(cam, cam1, eam, eam1, mam, mam1, loginTries, p);
                }
                catch (Exception)
                {
                    Console.Write("Incorrect format. Please try again");
                    ConsoleIO.ReadLine();
                }
            }
            
            
            

        }
        public void performOperation(CustomerAccountManager cam, CustomersManager cam1, EmployeeAccountManager eam, BankEmployeesManager eam1, ManagerAccountManager mam, BankManagersManager mam1, List<int> loginTries, Program p)
        {
            ConsoleIO.WriteLine("Starting Program..");
            bool exit = false;
            while (!exit)
            {
                p.Initialize();
                ConsoleIO.WriteLine("ENTER YOUR CHOICE:");
                var action = ConsoleIO.ReadLine();

                switch (action)
                {
                    case "1":
                        {

                            Console.Clear(); cam1.PerformOperation(cam, eam, mam, loginTries); ConsoleIO.WriteLine("1 : Savings" + "\n2 : Loan" + "\n3 : Go Back");


                            var choice = ConsoleIO.ReadLine();

                            switch (choice)
                            {
                                case "1":
                                    {
                                        Savings saving = new Savings();
                                        saving.performOperation(cam, eam, mam);
                                        break;
                                    }
                                case "2":
                                    {


                                        TakingLoan tk = new TakingLoan();
                                        tk.performOperation(cam, eam, mam);
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
                            eam1.PerformOperation(cam, eam, mam); ConsoleIO.WriteLine("ok cleared"); ConsoleIO.ReadLine();


                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            mam1.performOperationAdvanced(cam, cam1, eam, eam1, mam, mam1); ConsoleIO.WriteLine("ok seen manager"); ConsoleIO.ReadLine();


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
            ConsoleIO.WriteLine("Exiting the program");
            ConsoleIO.ReadLine();
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
            

        }
    }
}
