using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OrganizationExamSystem
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine("1 : Sign up as a student for exam");
                    Console.WriteLine("2 :  List approved student");
                    Console.WriteLine("3 : Approved student, take exam");
                    Console.WriteLine("4 :  List all students results");
                    Console.WriteLine("5 : Exit");
                    int input = Int32.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            {
                                Console.WriteLine("Sign up new student in: Y / N");
                                string input1 = Console.ReadLine();
                                if (input1 == "Y" || input1 == "y")
                                {
                                    Admin admin = new Admin();
                                    Console.WriteLine("Enter student id: ");
                                    int studentID = Int32.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter student name");
                                    string studentName = Console.ReadLine();

                                    Console.WriteLine("Enter vaccinnation status, true or false");
                                    bool vaccination = bool.Parse(Console.ReadLine());
                                    if (vaccination == true)
                                    {
                                        Thread t2 = new Thread(() => { admin.AddStudent(new Student(studentID, studentName, vaccination, 0, false)); });
                                        t2.Start();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sorry non vaccination students not allowed");
                                    }
                                    

                                }
                                break;

                            }

                        case 2:
                            {
                                Admin admin = new Admin();
                                Thread t4 = new Thread(() => { admin.ListStudents(); });
                                t4.Start();
                                break;
                            }

                        case 3:
                            {
                                Admin admin = new Admin();
                                Console.WriteLine("Enter your student ID");
                                int studentid = Int32.Parse(Console.ReadLine());
                                int score = 0;
                                bool alreadyStored = Admin.students.Any(x => x.Value.Item4 == false);   // linq to check if exam (4th param) already taken exam is false in dictionary
                                if (Admin.students.ContainsKey(studentid) && alreadyStored)   // static so dont need to instantiate
                                {
                                    Console.WriteLine("Q1. What is square root of 256?");
                                    Console.WriteLine("1) 12");
                                    Console.WriteLine("2) 14");
                                    Console.WriteLine("3) 16");
                                    int answer1 = Int32.Parse(Console.ReadLine());
                                    switch (answer1)
                                    {
                                        case 1:
                                            {
                                                Console.WriteLine("Wrong answer! Correct answer is 3) 16");
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("Wrong answer! Correct answer is 3) 16");
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.WriteLine("Correct answer!");
                                                score++;
                                                break;
                                            }
                                    }
                                    Console.WriteLine("Q2. Which number is a prime number below?");
                                    Console.WriteLine("1) 28");
                                    Console.WriteLine("2) 31");
                                    Console.WriteLine("3) 36");
                                    int answer2 = Int32.Parse(Console.ReadLine());
                                    switch (answer2)
                                    {
                                        case 1:
                                            {
                                                Console.WriteLine("Wrong answer! Correct answer is 2) 31");
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("Correct answer!");
                                                score++;
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.WriteLine("Wrong answer! Correct answer is 2) 31");
                                                break;
                                            }
                                    }
                                    Console.WriteLine("Q3. Which of the following converts a type to a string in C#?");
                                    Console.WriteLine("1) ToInt64");
                                    Console.WriteLine("2) ToString");
                                    Console.WriteLine("3) ToSingle");
                                    int answer3 = Int32.Parse(Console.ReadLine());
                                    switch (answer3)
                                    {
                                        case 1:
                                            {
                                                Console.WriteLine("Wrong answer! Correct answer is 2) ToString");
                                                
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("Correct answer!");
                                                score++;
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.WriteLine("Wrong answer! Correct answer is 2) ToString");
                                                break;
                                            }
                                    }
                                    Console.WriteLine("Q4. SOAP stands for");
                                    Console.WriteLine("1) Simple Object Access Protocol");
                                    Console.WriteLine("2) Simple Object Access Program");
                                    Console.WriteLine("3) Simple Object Application Protocol");
                                    int answer4 = Int32.Parse(Console.ReadLine());
                                    switch (answer4)
                                    {
                                        case 1:
                                            {
                                                Console.WriteLine("Correct answer!");
                                                score++;
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("Wrong answer! Correct answer is 1) Simple Object Access Protocol");
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.WriteLine("Wrong answer! Correct answer is 1) Simple Object Access Protocol");
                                                break;
                                            }
                                    }
                                    Console.WriteLine("Your final score: " + score + "/4");
                                    Admin.students[studentid] = new Tuple<string, bool, int, bool>("", true, score, true); //update the score in the dictionary
                                    Console.WriteLine("ok pass");
                                }
                                else
                                {
                                    Console.WriteLine("Already took exam or");
                                    Console.WriteLine("no student id in exam database");
                                }
                                foreach(var s in Admin.students)
                                {

                                }


                                break;
                            }

                        case 4:
                            {
                                Admin result = new Admin();
                                result.ListStudentsResults();
                                break;
                            }
                        case 5:
                            {
                                loop = false;
                                break;
                            }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrectformat");
                }
                finally
                {

                }
                
                

                
            }
            Console.WriteLine("Exiting program");
            Console.ReadLine();

        }
    }
}
