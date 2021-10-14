using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office_Management_System
{
    class Admin
    {
        public static void TaskAssigned()
        {
            bool exit = false;
            Console.WriteLine("Key employee id:");
            string user_id = Console.ReadLine();


            if (SuperAdmin.dictionaryOfUsers.ContainsKey(user_id))
            {
                while (!exit)
                {
                    Console.WriteLine("ok user found");

                    Console.WriteLine("Press continue to assign task, to any employee");
                    Console.WriteLine("1: Task 1");
                    Console.WriteLine("2: Task 2");
                    Console.WriteLine("3: Task 3");
                    Console.WriteLine("4: Call assistance");
                    Console.WriteLine("5: Search for ID to check for any detailed report submitted");
                    Console.WriteLine("6: View all users and leave admin room");
                    int choice = Int32.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine(user_id + " has been assigned to Task 1");
                                SuperAdmin.dictionaryOfUsers[user_id].task_assigned = " Task 1";
                                Console.ReadLine();
                                string text = "ID " + user_id + ".txt";
                                FileStream fs = new FileStream(text, FileMode.Create, FileAccess.Write);
                                StreamWriter streamWriter = new StreamWriter(fs);

                                Console.WriteLine($"Dear Employee, your details for your task, please submit a detailed report: { SuperAdmin.dictionaryOfUsers[user_id].user_id} { SuperAdmin.dictionaryOfUsers[user_id].user_name} { SuperAdmin.dictionaryOfUsers[user_id].user_email} { SuperAdmin.dictionaryOfUsers[user_id].task_assigned}");



                                streamWriter.WriteLine($"Dear Employee, your details for your task, please submit a detailed report: { SuperAdmin.dictionaryOfUsers[user_id].user_id} { SuperAdmin.dictionaryOfUsers[user_id].user_name} { SuperAdmin.dictionaryOfUsers[user_id].user_email} { SuperAdmin.dictionaryOfUsers[user_id].task_assigned}");
                                streamWriter.Flush();
                                streamWriter.Close();
                                fs.Close();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine(user_id + " has been assigned to Task 2");
                                SuperAdmin.dictionaryOfUsers[user_id].task_assigned = " Task 2";
                                Console.ReadLine();
                                string text = "ID " + user_id + ".txt";
                                FileStream fs = new FileStream(text, FileMode.Create, FileAccess.Write);
                                StreamWriter streamWriter = new StreamWriter(fs);

                                Console.WriteLine($"Dear Employee, your details for your task, please submit a detailed report: { SuperAdmin.dictionaryOfUsers[user_id].user_id} { SuperAdmin.dictionaryOfUsers[user_id].user_name} { SuperAdmin.dictionaryOfUsers[user_id].user_email} { SuperAdmin.dictionaryOfUsers[user_id].task_assigned}");



                                streamWriter.WriteLine($"Dear Employee, your details for your task, please submit a detailed report: { SuperAdmin.dictionaryOfUsers[user_id].user_id} { SuperAdmin.dictionaryOfUsers[user_id].user_name} { SuperAdmin.dictionaryOfUsers[user_id].user_email} { SuperAdmin.dictionaryOfUsers[user_id].task_assigned}");
                                streamWriter.Flush();
                                streamWriter.Close();
                                fs.Close();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine(user_id + " has been assigned to Task 3");
                                SuperAdmin.dictionaryOfUsers[user_id].task_assigned = " Task 3";
                                Console.ReadLine();
                                string text = "ID " + user_id + ".txt";
                                FileStream fs = new FileStream(text, FileMode.Create, FileAccess.Write);
                                StreamWriter streamWriter = new StreamWriter(fs);

                                Console.WriteLine($"Dear Employee, your details for your task, please submit a detailed report: { SuperAdmin.dictionaryOfUsers[user_id].user_id} { SuperAdmin.dictionaryOfUsers[user_id].user_name} { SuperAdmin.dictionaryOfUsers[user_id].user_email} { SuperAdmin.dictionaryOfUsers[user_id].task_assigned}");



                                streamWriter.WriteLine($"Dear Employee, your details for your task, please submit a detailed report: { SuperAdmin.dictionaryOfUsers[user_id].user_id} { SuperAdmin.dictionaryOfUsers[user_id].user_name} { SuperAdmin.dictionaryOfUsers[user_id].user_email} { SuperAdmin.dictionaryOfUsers[user_id].task_assigned}");
                                streamWriter.Flush();
                                streamWriter.Close();
                                fs.Close();
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Please hold on... we are trying to ");
                                Console.ReadLine();
                                break;
                            }
                        case 5:
                            {
                                string text = "ID " + user_id + ".txt";
                                FileStream fs1 = new FileStream(text, FileMode.Open, FileAccess.Read);
                                StreamReader sr1 = new StreamReader(fs1);
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
                                fs1.Close();

                                Console.ReadLine();
                                break;
                            }
                        case 6:
                            {
                                SuperAdmin.ListAllUsers();
                                exit = true;
                                break;
                            }
                    }
                }
            }
            else
            {
                Console.WriteLine("User id not in current database system");
            }
        }
    }
}
