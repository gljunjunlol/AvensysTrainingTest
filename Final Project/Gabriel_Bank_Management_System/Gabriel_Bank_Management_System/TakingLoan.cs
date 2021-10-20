using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gabriel_Bank_Management_System
{
    class TakingLoan
    {
        public static void LoanAccount()
        {
            Console.WriteLine("Lets take a loan");
            Console.WriteLine("Enter the customer detail:");
            Console.WriteLine("Enter customer ID");
            string customer_id = Console.ReadLine();
            if (CustomersManagement.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                if (CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied == false)
                {
                    Console.WriteLine("Enter loan application amount");
                    decimal loanamount = decimal.Parse(Console.ReadLine());
                    DateTime datetime = DateTime.Now;
                    Console.WriteLine("Taking a loan at: " + datetime);

                    Console.WriteLine("Key in amount of months to repay / installment");
                    decimal months = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Key in % of interest of loan");
                    decimal interest = decimal.Parse(Console.ReadLine());

                    // principal loan amount * interest rate * number of years in term = total interest paid
                    Console.WriteLine("Total loan calculated after interest");
                    decimal totalloanamount = loanamount + (loanamount * (interest/100) * (months / 12));
                    Console.WriteLine(totalloanamount.ToString("F"));
                    Console.WriteLine("");
                    Console.WriteLine("Checking for approval....");
                    Console.WriteLine("Loan of: $" + totalloanamount.ToString("F") + " will repay in" + months + " installments or $" + (totalloanamount / months).ToString("F") + " monthly"  );
                    Console.WriteLine("Loan application : ID : " + CustomersManagement.dictionaryOfcustomers[customer_id] + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name);

                    CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied = true;
                    CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount = totalloanamount;

                    try
                    {

                        // first time writing customer details to file
                        string text = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                        FileStream fs = new FileStream(text, FileMode.Create, FileAccess.Write);
                        StreamWriter streamWriter = new StreamWriter(fs);

                        Console.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount}");



                        streamWriter.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount}");
                        streamWriter.Flush();
                        streamWriter.Close();
                        fs.Close();

                        // first time reading customer details on file
                        FileStream fs2 = new FileStream(text, FileMode.Open, FileAccess.Read);
                        StreamReader sr1 = new StreamReader(fs2);
                        Console.WriteLine("Printing content of text file after written detailed report");
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

                        // Json format - first time writing
                        Customer cust = new Customer()  // object creation
                        {
                            customer_id = CustomersManagement.dictionaryOfcustomers[customer_id].customer_id,
                            customer_name = CustomersManagement.dictionaryOfcustomers[customer_id].customer_name,
                            customer_address = CustomersManagement.dictionaryOfcustomers[customer_id].customer_address,
                            customer_dateOfBirth = CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth,
                            customer_email = CustomersManagement.dictionaryOfcustomers[customer_id].customer_email,
                            customer_phone = CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone,
                            customer_loan_applied = CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied,
                            loan_amount = CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount,

                        };
                        string jsontext = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".json";
                        //if (File.Exists(jsontext))
                        //    File.Delete(jsontext);
                        List<Customer> customerList = new List<Customer>();
                        customerList.Add(cust);
                        Console.WriteLine("uploading user details to json file");
                        string customerListJson = JsonConvert.SerializeObject(customerList, Formatting.Indented);
                        //File.Create("Customer.Json");
                        File.WriteAllText(jsontext, customerListJson);

                        //Console.ReadLine();
                        List<Customer> empTemp = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(jsontext));
                        Console.ReadLine();
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
                
                else
                {
                    Console.WriteLine("Already applied for loan which is unpaid");
                }         
            }
            else
            {
                Console.WriteLine("Account doesn't exist in our database record");
            }
                

        }
        public static void CancelLoan()
        {
            Console.WriteLine("Enter the customer detail:");
            Console.WriteLine("Cancel current loan (only applicable 7 days before, will be rejected if not met");
            Console.WriteLine("Enter customer ID");
            string customer_id = Console.ReadLine();
            if (CustomersManagement.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                if (CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied == true)
                {
                    try
                    {

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Key in date as MM DDD YYYY ");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Key in date as MM DDD YYYY ");
                    }
                    Console.WriteLine("Key in date you have applied for the loan");
                    DateTime loanApplied = DateTime.Parse(Console.ReadLine());
                    DateTime datetime = DateTime.Now;
                    
                    Console.WriteLine("Difference in time is " + (datetime - loanApplied).TotalDays + " Days");
                    double todayDays = (datetime - loanApplied).TotalDays;

                    if (todayDays > 7)
                    {
                        Console.WriteLine("Sorry loan taken too long ago");
                    }
                    else
                    {
                        Console.WriteLine("ok loan has been cancelled as requested on " + DateTime.Now);
                        CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied = false;
                        CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount = 0;
                        try
                        {

                            // first time writing customer details to file
                            string text = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                            FileStream fs = new FileStream(text, FileMode.Create, FileAccess.Write);
                            StreamWriter streamWriter = new StreamWriter(fs);

                            Console.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount}");



                            streamWriter.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount}");
                            streamWriter.Flush();
                            streamWriter.Close();
                            fs.Close();

                            // first time reading customer details on file
                            FileStream fs2 = new FileStream(text, FileMode.Open, FileAccess.Read);
                            StreamReader sr1 = new StreamReader(fs2);
                            Console.WriteLine("Printing content of text file after written detailed report");
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

                            // Json format - first time writing
                            Customer cust = new Customer()  // object creation
                            {
                                customer_id = CustomersManagement.dictionaryOfcustomers[customer_id].customer_id,
                                customer_name = CustomersManagement.dictionaryOfcustomers[customer_id].customer_name,
                                customer_address = CustomersManagement.dictionaryOfcustomers[customer_id].customer_address,
                                customer_dateOfBirth = CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth,
                                customer_email = CustomersManagement.dictionaryOfcustomers[customer_id].customer_email,
                                customer_phone = CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone,
                                customer_loan_applied = CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied,
                                loan_amount = CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount,

                            };
                            string jsontext = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".json";
                            //if (File.Exists(jsontext))
                            //    File.Delete(jsontext);
                            List<Customer> customerList = new List<Customer>();
                            customerList.Add(cust);
                            Console.WriteLine("uploading user details to json file");
                            string customerListJson = JsonConvert.SerializeObject(customerList, Formatting.Indented);
                            //File.Create("Customer.Json");
                            File.WriteAllText(jsontext, customerListJson);

                            //Console.ReadLine();
                            List<Customer> empTemp = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(jsontext));
                            Console.ReadLine();
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
                else
                {
                    Console.WriteLine("No loan applied with us in our database");
                }
            }
            else
            {
                Console.WriteLine("Account doesn't exist in our database record");
            }
        }

        public static void ViewLoan()
        {
            Console.WriteLine("Enter customer ID");
            string customer_id = Console.ReadLine();
            if (CustomersManagement.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                if (CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied == true)
                {
                    Console.WriteLine("Current loan is at $" + CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount.ToString("F"));
                }
                else
                {
                    Console.WriteLine("Current loan is at $0");
                }
                    
            }
            else
            {
                Console.WriteLine("Account doesn't exist in our database record");
            }
        }

        public static void AddLoan()
        {
            Console.WriteLine("Enter customer ID");
            string customer_id = Console.ReadLine();
            if (CustomersManagement.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                if (CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied == false)
                {
                    Console.WriteLine("Have you taken a loan with us before? Y/N, if no please go to apply for a new loan");
                    string input = Console.ReadLine();
                    string input1 = input.ToUpper();
                    if (input1 == "Y" || input1 == "YES" || input1 == "YA" || input1 == "YE")
                    {
                        Console.WriteLine("Enter additional loan application amount");
                        decimal loanamount = decimal.Parse(Console.ReadLine());
                        DateTime datetime = DateTime.Now;
                        Console.WriteLine("Taking a loan at: " + datetime);

                        Console.WriteLine("Key in amount of months to repay / installment");
                        decimal months = decimal.Parse(Console.ReadLine());

                        Console.WriteLine("Key in % of interest of loan");
                        decimal interest = decimal.Parse(Console.ReadLine());

                        // principal loan amount * interest rate * number of years in term = total interest paid
                        Console.WriteLine("Total loan calculated after interest");
                        decimal totalloanamount = loanamount + (loanamount * (interest / 100) * (months / 12));
                        Console.WriteLine(totalloanamount.ToString("F"));
                        Console.WriteLine("");
                        Console.WriteLine("Checking for approval....");

                        Console.WriteLine("Loan of: $" + totalloanamount.ToString("F") + " will repay in " + months + " installments or $" + (totalloanamount / months).ToString("F") + " monthly");
                        Console.WriteLine("Loan application : ID : " + CustomersManagement.dictionaryOfcustomers[customer_id] + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name);

                        CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied = true;
                        CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount = totalloanamount;
                        try
                        {

                            // first time writing customer details to file
                            string text = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                            FileStream fs = new FileStream(text, FileMode.Create, FileAccess.Write);
                            StreamWriter streamWriter = new StreamWriter(fs);

                            Console.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount}");



                            streamWriter.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount}");
                            streamWriter.Flush();
                            streamWriter.Close();
                            fs.Close();

                            // first time reading customer details on file
                            FileStream fs2 = new FileStream(text, FileMode.Open, FileAccess.Read);
                            StreamReader sr1 = new StreamReader(fs2);
                            Console.WriteLine("Printing content of text file after written detailed report");
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

                            // Json format - first time writing
                            Customer cust = new Customer()  // object creation
                            {
                                customer_id = CustomersManagement.dictionaryOfcustomers[customer_id].customer_id,
                                customer_name = CustomersManagement.dictionaryOfcustomers[customer_id].customer_name,
                                customer_address = CustomersManagement.dictionaryOfcustomers[customer_id].customer_address,
                                customer_dateOfBirth = CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth,
                                customer_email = CustomersManagement.dictionaryOfcustomers[customer_id].customer_email,
                                customer_phone = CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone,
                                customer_loan_applied = CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied,
                                loan_amount = CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount,

                            };
                            string jsontext = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".json";
                            //if (File.Exists(jsontext))
                            //    File.Delete(jsontext);
                            List<Customer> customerList = new List<Customer>();
                            customerList.Add(cust);
                            Console.WriteLine("uploading user details to json file");
                            string customerListJson = JsonConvert.SerializeObject(customerList, Formatting.Indented);
                            //File.Create("Customer.Json");
                            File.WriteAllText(jsontext, customerListJson);

                            //Console.ReadLine();
                            List<Customer> empTemp = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(jsontext));
                            Console.ReadLine();
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
                    else
                    {
                        TakingLoan.performOperation();
                        Console.WriteLine("Going back to main screen");
                    }
                    
                    
                }
                else
                {
                    Console.WriteLine("Sorry cant take additional loan as previous loan is still outstanding");
                }
            }

        }
        public static void RepayLoan()
        {
            Console.WriteLine("Enter customer ID");
            string customer_id = Console.ReadLine();
            if (CustomersManagement.dictionaryOfcustomers.ContainsKey(customer_id))
            {
                if (CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied == true)
                {
                    Console.WriteLine("Current loan is at " + CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount.ToString("F"));
                    Console.WriteLine("Key amount of loan or % of loan to repay");
                    Console.WriteLine("E.g. key in 100 to repay 100 or / key in  6% to repay 6%");
                    string repayLoan = Console.ReadLine();
                    if (repayLoan.Contains("%") == true)
                    {
                        var charsToRemove = new string[] { "%" };
                        foreach(var c in charsToRemove)
                        {
                            repayLoan = repayLoan.Replace(c, string.Empty);
                        }
                        decimal repayLoan2 = decimal.Parse(repayLoan);
                        decimal amountToRepay = repayLoan2 * CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount / 100;
                        Console.WriteLine("Amount to repay is: $" + amountToRepay);
                        decimal remainingLoanLeft = CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount - amountToRepay;
                        if (amountToRepay > CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount)
                        {
                            Console.WriteLine("Exceed loan repayment, key again");
                        }
                        else
                        {
                            Console.WriteLine("Loan amount left: $" + remainingLoanLeft);
                            CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount = remainingLoanLeft;

                            try
                            {
                                // first time writing customer details to file
                                string text = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                                FileStream fs = new FileStream(text, FileMode.Create, FileAccess.Write);
                                StreamWriter streamWriter = new StreamWriter(fs);

                                Console.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount}");



                                streamWriter.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount}");
                                streamWriter.Flush();
                                streamWriter.Close();
                                fs.Close();

                                // first time reading customer details on file
                                FileStream fs2 = new FileStream(text, FileMode.Open, FileAccess.Read);
                                StreamReader sr1 = new StreamReader(fs2);
                                Console.WriteLine("Printing content of text file after written detailed report");
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

                                // Json format - first time writing
                                Customer cust = new Customer()  // object creation
                                {
                                    customer_id = CustomersManagement.dictionaryOfcustomers[customer_id].customer_id,
                                    customer_name = CustomersManagement.dictionaryOfcustomers[customer_id].customer_name,
                                    customer_address = CustomersManagement.dictionaryOfcustomers[customer_id].customer_address,
                                    customer_dateOfBirth = CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth,
                                    customer_email = CustomersManagement.dictionaryOfcustomers[customer_id].customer_email,
                                    customer_phone = CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone,
                                    customer_loan_applied = CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied,
                                    loan_amount = CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount,

                                };
                                string jsontext = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".json";
                                //if (File.Exists(jsontext))
                                //    File.Delete(jsontext);
                                List<Customer> customerList = new List<Customer>();
                                customerList.Add(cust);
                                Console.WriteLine("uploading user details to json file");
                                string customerListJson = JsonConvert.SerializeObject(customerList, Formatting.Indented);
                                //File.Create("Customer.Json");
                                File.WriteAllText(jsontext, customerListJson);

                                //Console.ReadLine();
                                List<Customer> empTemp = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(jsontext));
                                Console.ReadLine();
                                if (remainingLoanLeft == 0)
                                {
                                    CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied = false;

                                    // first time writing customer details to file
                                    string text1 = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                                    FileStream fs1 = new FileStream(text, FileMode.Create, FileAccess.Write);
                                    StreamWriter streamWriter1 = new StreamWriter(fs1);

                                    Console.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount}");



                                    streamWriter1.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount}");
                                    streamWriter1.Flush();
                                    streamWriter1.Close();
                                    fs1.Close();

                                    // first time reading customer details on file
                                    FileStream fs3 = new FileStream(text1, FileMode.Open, FileAccess.Read);
                                    StreamReader sr2 = new StreamReader(fs3);
                                    Console.WriteLine("Printing content of text file after written detailed report");
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

                                    // Json format - first time writing
                                    Customer cust1 = new Customer()  // object creation
                                    {
                                        customer_id = CustomersManagement.dictionaryOfcustomers[customer_id].customer_id,
                                        customer_name = CustomersManagement.dictionaryOfcustomers[customer_id].customer_name,
                                        customer_address = CustomersManagement.dictionaryOfcustomers[customer_id].customer_address,
                                        customer_dateOfBirth = CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth,
                                        customer_email = CustomersManagement.dictionaryOfcustomers[customer_id].customer_email,
                                        customer_phone = CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone,
                                        customer_loan_applied = CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied,
                                        loan_amount = CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount,

                                    };
                                    string jsontext1 = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".json";
                                    //if (File.Exists(jsontext))
                                    //    File.Delete(jsontext);
                                    List<Customer> customerList1 = new List<Customer>();
                                    customerList1.Add(cust1);
                                    Console.WriteLine("uploading user details to json file");
                                    string customerListJson1 = JsonConvert.SerializeObject(customerList1, Formatting.Indented);
                                    //File.Create("Customer.Json");
                                    File.WriteAllText(jsontext1, customerListJson1);

                                    //Console.ReadLine();
                                    List<Customer> empTemp1 = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(jsontext1));
                                    Console.ReadLine();
                                }
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
                    else
                    {
                        decimal amountToRepay = decimal.Parse(repayLoan);
                        Console.WriteLine("Amount to repay is: $" + amountToRepay);
                        decimal remainingLoanLeft = CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount - amountToRepay;
                        if (amountToRepay > CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount)
                        {
                            Console.WriteLine("Exceed loan repayment, key again");
                        }
                        else
                        {
                            Console.WriteLine("Loan amount left: $" + remainingLoanLeft);
                            CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount = remainingLoanLeft;
                            try
                            {
                                // first time writing customer details to file
                                string text = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                                FileStream fs = new FileStream(text, FileMode.Create, FileAccess.Write);
                                StreamWriter streamWriter = new StreamWriter(fs);

                                Console.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount}");



                                streamWriter.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount}");
                                streamWriter.Flush();
                                streamWriter.Close();
                                fs.Close();

                                // first time reading customer details on file
                                FileStream fs2 = new FileStream(text, FileMode.Open, FileAccess.Read);
                                StreamReader sr1 = new StreamReader(fs2);
                                Console.WriteLine("Printing content of text file after written detailed report");
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

                                // Json format - first time writing
                                Customer cust = new Customer()  // object creation
                                {
                                    customer_id = CustomersManagement.dictionaryOfcustomers[customer_id].customer_id,
                                    customer_name = CustomersManagement.dictionaryOfcustomers[customer_id].customer_name,
                                    customer_address = CustomersManagement.dictionaryOfcustomers[customer_id].customer_address,
                                    customer_dateOfBirth = CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth,
                                    customer_email = CustomersManagement.dictionaryOfcustomers[customer_id].customer_email,
                                    customer_phone = CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone,
                                    customer_loan_applied = CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied,
                                    loan_amount = CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount,

                                };
                                string jsontext = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".json";
                                //if (File.Exists(jsontext))
                                //    File.Delete(jsontext);
                                List<Customer> customerList = new List<Customer>();
                                customerList.Add(cust);
                                Console.WriteLine("uploading user details to json file");
                                string customerListJson = JsonConvert.SerializeObject(customerList, Formatting.Indented);
                                //File.Create("Customer.Json");
                                File.WriteAllText(jsontext, customerListJson);

                                //Console.ReadLine();
                                List<Customer> empTemp = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(jsontext));
                                Console.ReadLine();
                                if (remainingLoanLeft == 0)
                                {
                                    CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied = false;

                                    // first time writing customer details to file
                                    string text1 = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".txt";
                                    FileStream fs1 = new FileStream(text, FileMode.Create, FileAccess.Write);
                                    StreamWriter streamWriter1 = new StreamWriter(fs1);

                                    Console.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount}");



                                    streamWriter1.WriteLine($"Dear Customer, your details for your checking, please check the detailed report: { CustomersManagement.dictionaryOfcustomers[customer_id].customer_id} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_name} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_address} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_email} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone} { CustomersManagement.dictionaryOfcustomers[customer_id].customerBalance} { CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied} { CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount}");
                                    streamWriter1.Flush();
                                    streamWriter1.Close();
                                    fs1.Close();

                                    // first time reading customer details on file
                                    FileStream fs3 = new FileStream(text1, FileMode.Open, FileAccess.Read);
                                    StreamReader sr2 = new StreamReader(fs3);
                                    Console.WriteLine("Printing content of text file after written detailed report");
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

                                    // Json format - first time writing
                                    Customer cust1 = new Customer()  // object creation
                                    {
                                        customer_id = CustomersManagement.dictionaryOfcustomers[customer_id].customer_id,
                                        customer_name = CustomersManagement.dictionaryOfcustomers[customer_id].customer_name,
                                        customer_address = CustomersManagement.dictionaryOfcustomers[customer_id].customer_address,
                                        customer_dateOfBirth = CustomersManagement.dictionaryOfcustomers[customer_id].customer_dateOfBirth,
                                        customer_email = CustomersManagement.dictionaryOfcustomers[customer_id].customer_email,
                                        customer_phone = CustomersManagement.dictionaryOfcustomers[customer_id].customer_phone,
                                        customer_loan_applied = CustomersManagement.dictionaryOfcustomers[customer_id].customer_loan_applied,
                                        loan_amount = CustomersManagement.dictionaryOfcustomers[customer_id].loan_amount,

                                    };
                                    string jsontext1 = "ID " + customer_id + " " + CustomersManagement.dictionaryOfcustomers[customer_id].customer_name + ".json";
                                    //if (File.Exists(jsontext))
                                    //    File.Delete(jsontext);
                                    List<Customer> customerList1 = new List<Customer>();
                                    customerList1.Add(cust1);
                                    Console.WriteLine("uploading user details to json file");
                                    string customerListJson1 = JsonConvert.SerializeObject(customerList1, Formatting.Indented);
                                    //File.Create("Customer.Json");
                                    File.WriteAllText(jsontext1, customerListJson1);

                                    //Console.ReadLine();
                                    List<Customer> empTemp1 = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(jsontext1));
                                    Console.ReadLine();
                                }
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
                    Console.WriteLine("No loan to repay");
                }
            }
            else
            {
                Console.WriteLine("Account doesn't exist in our database record");
            }

        }
        public static void performOperation()
        {
            Console.WriteLine("Taking loan here");
            bool exit = false;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("In Loan account, key in required operation");
                    Console.WriteLine("1: Apply for a new loan");
                    Console.WriteLine("2: Apply for additional loan");
                    Console.WriteLine("3: Cancel Loan");
                    Console.WriteLine("4: view the loan");
                    Console.WriteLine("5: Repay loan amount");
                    Console.WriteLine("6: Exit loans operation");
                    int input = Int32.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            {
                                LoanAccount();
                                break;
                            }
                        case 2:
                            {
                                AddLoan();
                                break;
                            }
                        case 3:
                            {
                                CancelLoan();
                                break;
                            }
                        case 4:
                            {
                                ViewLoan();
                                break;
                            }
                        case 5:
                            {
                                RepayLoan();
                                break;
                            }
                        case 6:
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
    }
}
