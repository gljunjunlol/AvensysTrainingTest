using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class ArrayExample
    {
        private int[] array = new int[10];
        
        public int this[int i]
        {
            get
            {
                return array[i];
            }
            set
            {
                array[i] = value;
            }
        }
    }
    class Customer
    {
        public int CustomerID { get; private set; }
        public string CustomerName { get; private set; }

        public Customer(int ID, string Name)
        {
            CustomerID = ID;
            CustomerName = Name;

        }
        
    }
    class Program
    {
        private static void DivideMultiply()
        {
            


            int MultiplyResult = 0;
            int DivideResult = 0;
            
            try
            {
                Console.WriteLine("Question 1");
                Console.WriteLine("Enter first number");
                int a = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter second number");
                int b = Int32.Parse(Console.ReadLine());
                MultiplyResult = a * b;

                DivideResult  = a / b;


            }
            catch (OverflowException)
            {
                Console.WriteLine("number too large for int");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Exception raised Format {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Exception raised DividebyZero {ex.Message}");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Exception raised Null {ex.Message}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Exception raised IndexOutofRange {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception raised Exception {ex.Message}");
            }
            finally
            {
                Console.WriteLine("");
                Console.WriteLine($"This is - Running finally block");
            }
            Console.WriteLine("Multiplication at " + MultiplyResult);
            Console.WriteLine("Division at " + DivideResult);
            Console.ReadLine();
        }

        private static void CheckDirectory()
        {
            string path = @"c:/Directory";
            string subpath = @"c:/Directory/Sub";
            string filename = @"c:/Directory/Sub/TempFile.txt";

            try
            {
                Console.WriteLine("Question 2");
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(subpath);
                File.Create(filename);
                File.OpenText(filename);
                File.CreateText(filename);
                
                
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("drive not found");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("file not find");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("UnauthorizedAccessException : cannot create file");
            }
            catch (IOException)
            {
                Console.WriteLine("UnauthorizedAccessException : cannot create file");
            }
            finally
            {

            }
            Console.WriteLine(path);
            Console.WriteLine("");
        }

        private static void Stack()
        {
            try
            {
                // Create and initialize a stack
                Console.WriteLine("Question 3");
                
                bool loop = true;
                while (loop)
                {
                    Stack<int> stk = new Stack<int>();
                    Console.WriteLine("Key in 1 to push to stack or 2 to pop from stack:");
                    Console.WriteLine("Stack is at zero..");
                    Console.WriteLine();
                    int input1 = Int32.Parse(Console.ReadLine());


                    if (input1 == 1)
                    {
                        stk.Push(1);
                        Console.WriteLine("Added");
                        continue;
                    }
                    if (input1 == 2)
                    {
                        stk.Pop();
                        Console.WriteLine("Removed");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("ok");
                    }



                    Console.WriteLine("New stack created in stack are values: " + string.Join(" ", stk));

                    Console.WriteLine("Number of Elements in Stack: {0}", stk.Count);
                    Console.WriteLine("******Stack Elements******");
                    // Access Stack Elements
                    Console.WriteLine("Last element value in stack: " + stk.Peek());
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Loading....");
                    Console.WriteLine("Popping out last element in the stack (LIFO): ");
                    Console.WriteLine("");
                    Console.WriteLine("Number of Elements in Stack left: {0}", stk.Count);

                    Console.WriteLine("");
                    Console.WriteLine("Checking if stack contains a certain element: ");
                    Console.WriteLine("");
                    Console.WriteLine("Contains Element 4: {0}", stk.Contains(4));
                    Console.WriteLine("Contains Element 100: {0}", stk.Contains(100));
                    Console.WriteLine("Contains Element 3': {0}", stk.Contains(3));
                    Console.ReadLine();
                }
                
            }
                
            
            catch(InvalidOperationException)
            {
                Console.WriteLine("Stack is empty, cant remove more");
            }
            catch (Exception)
            {
                Console.WriteLine("Stack is empty, cant remove more");
            }

            finally
            {
                Console.WriteLine();
            }
            
        }

        private static void Array()
        {
            ArrayExample array = new ArrayExample();
            try
            {
                Console.WriteLine("Question 4");
                array[0] = 13;
                array[1] = 14;
                array[1] = 15;
                array[20] = 16;
                Console.WriteLine($"print {0} index " + string.Join(" ", array[0]));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(" out of range");
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
            finally
            {
                Console.WriteLine();
            }


        }



        Dictionary<int, string> customers = new Dictionary<int, string>();

        public void CustomerInformation(Customer customer)
        {

            try
            {
                Console.WriteLine("Enter any key from 1 - 10 to check if customer id exists");
                int input5 = Int32.Parse(Console.ReadLine());
                if (customers.ContainsKey(input5))
                {
                    Console.WriteLine("Question 5");
                    Console.WriteLine($"Customer id is " + input5 + " ," + customers.ContainsKey(input5) + $" customer id is currently in our customer database");
                }
                else
                {
                    Console.WriteLine("it is not found");
                }

            }

            catch (KeyNotFoundException)
            {
                Console.WriteLine("Customer not found\n");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("enter correct format");
            }
                
            
            




        }
        public void AddCustomer(Customer customer)
        {
            customers.Add(customer.CustomerID, customer.CustomerName);
        }
        static void Main(string[] args)
            {
            Program p1 = new Program();
            Customer c1 = new Customer(1, "John");
            Customer c2 = new Customer(2, "Sam");
            Customer c3 = new Customer(3, "Peter");
            Customer c4 = new Customer(4, "Gates");
            Customer c5 = new Customer(5, "Matthew");

            p1.AddCustomer(c1);
            p1.AddCustomer(c2);
            p1.AddCustomer(c3);
            p1.AddCustomer(c4);
 

            p1.CustomerInformation(c1);
            p1.CustomerInformation(c2);
            p1.CustomerInformation(c5);

            Console.ReadLine();


                
            Array();
            Stack();
            CheckDirectory();
            DivideMultiply();

            Console.ReadLine();
            }
        }
    }
