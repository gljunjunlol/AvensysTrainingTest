using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Gabriel_Bank_Management_System
{
    class Savings
    {
        public static Dictionary<int, Guid> cheque = new Dictionary<int, Guid>();

        public static void performOperation()
        {
            bool exit = false;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("In Savings account, key in operation");
                    Console.WriteLine("1: withdraw money");
                    Console.WriteLine("2: deposit money");
                    Console.WriteLine("3: view the balance");
                    Console.WriteLine("4: Exit savings operation");
                    int input = Int32.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            {
                                customerWithdrawl();
                                break;
                            }
                        case 2:
                            {
                                customerDeposit();
                                break;
                            }
                        case 3:
                            {
                                ViewBalance();
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
            
        }
        public static void customerDeposit()
        {
            Console.WriteLine("Key in customer id");
            string customer_id = Console.ReadLine();
            if (CustomersManagement.dictionaryOfcustomers.ContainsKey(customer_id))
            {                
                Console.WriteLine("we will use cheque if more than 5k");
                Console.WriteLine("Key in amount for deposit");
                decimal depositAmountKeyedInByCustomer = Int32.Parse(Console.ReadLine());
                if (depositAmountKeyedInByCustomer <= 0)
                {
                    Console.WriteLine("deposit amount should be more than 0");
                }
                else
                {
                    if (depositAmountKeyedInByCustomer > 5000)
                    {
                        var guid1 = Guid.NewGuid();
                        Console.WriteLine("Amount is larger than 5000, we will process the cheque");
                        CustomersManagement.dictionaryOfcustomers[customer_id].cheque_book_number = guid1;
                        CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance = CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance + depositAmountKeyedInByCustomer;
                        Console.WriteLine("{0} > {1} > {2}", CustomersManagement.dictionaryOfcustomers[customer_id], CustomersManagement.dictionaryOfcustomers[customer_id].customer_name, CustomersManagement.dictionaryOfcustomers[customer_id].cheque_book_number);

                        try
                        {
                            // writing customer details to file (cheque deposit)
                            string text1 = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                            FileStream fs1 = new FileStream(text1, FileMode.Append, FileAccess.Write);
                            StreamWriter streamWriter1 = new StreamWriter(fs1);

                            Console.WriteLine($"Dear Customer, your cheque deposit is: " + depositAmountKeyedInByCustomer);
                            Console.WriteLine($"Dear Customer, cheque number issued is: " + customer_id + "," + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ", have issued cheque " + guid1);
                            Console.WriteLine($"Dear Customer, check your customer information is matched to cheque number with cheque number details : " + "{0} > {1} > {2}", CustomersManagement.dictionaryOfcustomers[customer_id], CustomersManagement.dictionaryOfcustomers[customer_id].customer_name, CustomersManagement.dictionaryOfcustomers[customer_id].cheque_book_number);
                            Console.WriteLine($"Dear Customer, your current balance is: " + CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance);



                            streamWriter1.WriteLine($"Dear Customer, your cheque deposit is: " + depositAmountKeyedInByCustomer);
                            streamWriter1.WriteLine($"Dear Customer, cheque number issued is: " + customer_id + "," + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ", have issued cheque " + guid1);
                            streamWriter1.WriteLine($"Dear Customer, check your customer information is matched to cheque number with cheque number details : " + "{0} > {1} > {2}", CustomersManagement.dictionaryOfcustomers[customer_id], CustomersManagement.dictionaryOfcustomers[customer_id].customer_name, CustomersManagement.dictionaryOfcustomers[customer_id].cheque_book_number);
                            streamWriter1.WriteLine($"Dear Customer, your current balance is: " + CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance);
                            streamWriter1.Flush();
                            streamWriter1.Close();
                            fs1.Close();

                            // reading customer details on file (cheque deposit)
                            FileStream fs3 = new FileStream(text1, FileMode.Open, FileAccess.Read);
                            StreamReader sr2 = new StreamReader(fs3);
                            Console.WriteLine("Printing content of text file after deposit");
                            sr2.BaseStream.Seek(0, SeekOrigin.Begin);   // read from start, beginning of file
                            string str2 = sr2.ReadToEnd();   // if use ReadtoEnd then dont need while loop
                            Console.WriteLine(str2);
                            //while (str != null)
                            //{
                            //    Console.WriteLine(str);
                            //    str = sr.ReadLine();
                            //}
                            sr2.Close();
                            fs3.Close();
                        }
                        catch (NotSupportedException)
                        {
                            Console.WriteLine("The file or directory is not supported");
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Console.WriteLine("You do not have permission to create this file.");
                        }
                        catch (IOException)
                        {
                            Console.WriteLine($"The file already exist ");
                        }
                        catch (Exception)
                        {

                        }
                        finally
                        {

                        }
                        
                    }
                    if (depositAmountKeyedInByCustomer <= 5000)
                    {
                        Customer cmgt = new Customer();
                        cmgt.deposit(depositAmountKeyedInByCustomer);
                        CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance = CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance + depositAmountKeyedInByCustomer;
                        Console.WriteLine();

                        try
                        {
                            // writing customer details to file (deposit)
                            string text = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                            FileStream fs = new FileStream(text, FileMode.Append, FileAccess.Write);
                            StreamWriter streamWriter = new StreamWriter(fs);

                            Console.WriteLine($"Dear Customer, your deposit is: " + depositAmountKeyedInByCustomer);
                            Console.WriteLine($"Dear Customer, your current balance is: " + CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance);



                            streamWriter.WriteLine($"Dear Customer, your deposit is: " + depositAmountKeyedInByCustomer);
                            streamWriter.WriteLine($"Dear Customer, your current balance is: " + CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance);
                            streamWriter.Flush();
                            streamWriter.Close();
                            fs.Close();

                            // reading customer details on file (deposit)
                            FileStream fs2 = new FileStream(text, FileMode.Open, FileAccess.Read);
                            StreamReader sr1 = new StreamReader(fs2);
                            Console.WriteLine("Printing content of text file after deposit");
                            sr1.BaseStream.Seek(0, SeekOrigin.Begin);   // read from start, beginning of file
                            string str1 = sr1.ReadToEnd();   // if use ReadtoEnd then dont need while loop
                            Console.WriteLine(str1);
                            //while (str != null)
                            //{
                            //    Console.WriteLine(str);
                            //    str = sr.ReadLine();
                            //}
                            sr1.Close();
                            fs2.Close();
                        }
                        catch (NotSupportedException)
                        {
                            Console.WriteLine("The file or directory is not supported");
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Console.WriteLine("You do not have permission to create this file.");
                        }
                        catch (IOException)
                        {
                            Console.WriteLine($"The file already exist ");
                        }
                        catch (Exception)
                        {

                        }
                        finally
                        {

                        }
                    }
                }
                

            }
            else
            {
                Console.WriteLine("Account id not found");
            }
            
        }
        public static void customerWithdrawl()
        {
            Console.WriteLine("Key in customer id");
            string customer_id = Console.ReadLine();
            if (CustomersManagement.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                Console.WriteLine("we will use cheque if more than 5k");
                Console.WriteLine("Key in amount for withdrawal");                
                decimal withdrawAmountKeyedInByCustomer = Int32.Parse(Console.ReadLine());
                if (withdrawAmountKeyedInByCustomer <= 0)
                {
                    Console.WriteLine("withdrawal amount should be more than 0");
                }
                else
                {
                    if (CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance < withdrawAmountKeyedInByCustomer)
                    {
                        Console.WriteLine("Your balance does not meet the requirement, insufficient funds in balance ");
                        Console.WriteLine($"Dear Customer, your current balance is: " + CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance);
                        //Console.WriteLine("Bank overdraft of " + Math.Abs(Customer.customerBalance));
                    }
                    if (CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance >= withdrawAmountKeyedInByCustomer && withdrawAmountKeyedInByCustomer <= 5000)
                    {
                        Customer cmgt = new Customer();
                        cmgt.withdraw(withdrawAmountKeyedInByCustomer);
                        CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance = CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance - withdrawAmountKeyedInByCustomer;
                        Console.WriteLine(CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance);

                        try
                        {
                            // writing customer details to file (withdrawal)
                            string text = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                            FileStream fs = new FileStream(text, FileMode.Append, FileAccess.Write);
                            StreamWriter streamWriter = new StreamWriter(fs);

                            Console.WriteLine($"Dear Customer, you withdrawed: " + withdrawAmountKeyedInByCustomer);
                            Console.WriteLine($"Dear Customer, your current balance is: " + CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance);



                            streamWriter.WriteLine($"Dear Customer, you withdrawed: " + withdrawAmountKeyedInByCustomer);
                            Console.WriteLine("Total Balance amount in the account....");
                            Thread.Sleep(5000);
                            streamWriter.WriteLine($"Dear Customer, your current balance is: " + CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance);
                            streamWriter.Flush();
                            streamWriter.Close();
                            fs.Close();

                            // reading customer details on file (withdrawal)
                            FileStream fs2 = new FileStream(text, FileMode.Open, FileAccess.Read);
                            StreamReader sr1 = new StreamReader(fs2);
                            Console.WriteLine("Printing content of text file after withdrawal");
                            sr1.BaseStream.Seek(0, SeekOrigin.Begin);   // read from start, beginning of file
                            string str1 = sr1.ReadToEnd();   // if use ReadtoEnd then dont need while loop
                            Console.WriteLine(str1);
                            //while (str != null)
                            //{
                            //    Console.WriteLine(str);
                            //    str = sr.ReadLine();
                            //}
                            sr1.Close();
                            fs2.Close();
                        }
                        catch (NotSupportedException)
                        {
                            Console.WriteLine("The file or directory is not supported");
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Console.WriteLine("You do not have permission to create this file.");
                        }
                        catch (IOException)
                        {
                            Console.WriteLine($"The file already exist ");
                        }
                        catch (Exception)
                        {

                        }
                        finally
                        {

                        }
                        


                    }
                    if (CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance >= withdrawAmountKeyedInByCustomer && withdrawAmountKeyedInByCustomer > 5000)
                    {
                        Customer cmgt = new Customer();
                        cmgt.withdraw(withdrawAmountKeyedInByCustomer);
                        CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance = CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance - withdrawAmountKeyedInByCustomer;
                        Console.WriteLine(CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance);
                        Console.WriteLine("Amount is larger than 5000, we will search for the cheque");
                        var guid2 = Guid.NewGuid();
                        CustomersManagement.dictionaryOfcustomers[customer_id].cheque_book_number = guid2;
                        Console.WriteLine("{0} > {1} > {2}", CustomersManagement.dictionaryOfcustomers[customer_id], CustomersManagement.dictionaryOfcustomers[customer_id].customer_name, CustomersManagement.dictionaryOfcustomers[customer_id].cheque_book_number);

                        try
                        {
                            // writing customer details to file (cheque withdrawal)
                            string text1 = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                            FileStream fs1 = new FileStream(text1, FileMode.Append, FileAccess.Write);
                            StreamWriter streamWriter1 = new StreamWriter(fs1);

                            Console.WriteLine($"Dear Customer, your cheque withdraw amount is: " + withdrawAmountKeyedInByCustomer);
                            Console.WriteLine($"Dear Customer, cheque number used is: " + customer_id + "," + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ", have used cheque " + guid2);
                            Console.WriteLine($"Dear Customer, check your customer information is matched to cheque number with cheque number details : " + "{0} > {1} > {2}", CustomersManagement.dictionaryOfcustomers[customer_id], CustomersManagement.dictionaryOfcustomers[customer_id].customer_name, CustomersManagement.dictionaryOfcustomers[customer_id].cheque_book_number);
                            Console.WriteLine($"Dear Customer, your current balance is: " + CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance);



                            streamWriter1.WriteLine($"Dear Customer, your cheque withdraw amount is: " + withdrawAmountKeyedInByCustomer);
                            streamWriter1.WriteLine($"Dear Customer, cheque number used is: " + customer_id + "," + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ", have used cheque " + guid2);
                            streamWriter1.WriteLine($"Dear Customer, check your customer information is matched to cheque number with cheque number details : " + "{0} > {1} > {2}", CustomersManagement.dictionaryOfcustomers[customer_id], CustomersManagement.dictionaryOfcustomers[customer_id].customer_name, CustomersManagement.dictionaryOfcustomers[customer_id].cheque_book_number);
                            Console.WriteLine("Total Balance amount in the account....");
                            Thread.Sleep(5000);
                            streamWriter1.WriteLine($"Dear Customer, your current balance is: " + CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance);
                            streamWriter1.Flush();
                            streamWriter1.Close();
                            fs1.Close();

                            // reading customer details on file (cheque withdrawal)
                            FileStream fs3 = new FileStream(text1, FileMode.Open, FileAccess.Read);
                            StreamReader sr2 = new StreamReader(fs3);
                            Console.WriteLine("Printing content of text file after deposit");
                            sr2.BaseStream.Seek(0, SeekOrigin.Begin);   // read from start, beginning of file
                            string str2 = sr2.ReadToEnd();   // if use ReadtoEnd then dont need while loop
                            Console.WriteLine(str2);
                            //while (str != null)
                            //{
                            //    Console.WriteLine(str);
                            //    str = sr.ReadLine();
                            //}
                            sr2.Close();
                            fs3.Close();


                            Console.WriteLine($"Dear Customer, your current balance is: " + CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance);
                        }
                        catch (NotSupportedException)
                        {
                            Console.WriteLine("The file or directory is not supported");
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Console.WriteLine("You do not have permission to create this file.");
                        }
                        catch (IOException)
                        {
                            Console.WriteLine($"The file already exist ");
                        }
                        catch (Exception)
                        {

                        }
                        finally
                        {

                        }
                        


                    }
                }
                

                
                
                
                

                

                
            }
            else
            {
                Console.WriteLine("Account id not found");
            }

        }
        public static void ViewBalance()
        {
            Console.WriteLine("Key in customer id");
            string customer_id = Console.ReadLine();
            if (CustomersManagement.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                Console.WriteLine("Customer balance is " + CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance);
            }
        }
    }
}
