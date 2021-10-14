using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office_Management_System
{
    class SuperAdmin : Admin
    {
        public static Dictionary<string, User> dictionaryOfUsers = new Dictionary<string, User>();

        public SuperAdmin()
        {
            if (!File.Exists("Office.txt"))
            {
                Console.WriteLine("!!!!No Previous Data Exist!!!!");
                return;
            }
            FileStream fs = new FileStream("User details.txt", FileMode.Open, FileAccess.Read);
            fs.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(fs);

            string str = sr.ReadLine();
            while (str != null)
            {
                var strarr = str.Split('_');    //get array of customer id ..etc in string
                var user = new User(strarr[0], strarr[1], strarr[2], strarr[3]);
                if (dictionaryOfUsers.ContainsKey(strarr[0]))
                {
                    dictionaryOfUsers.Add(strarr[0], user);
                }
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }

        public void PerformOperation()
        {
            bool user_exited = false;
            while (!user_exited)
            {
                try
                {
                    Console.WriteLine("Select Option");
                    Console.WriteLine("1. Create User");
                    Console.WriteLine("2: Remove User");
                    Console.WriteLine("3: View all users");
                    Console.WriteLine("4: Ask user to log in");
                    Console.WriteLine("5: End the program");
                    int user_option = Int32.Parse(Console.ReadLine());

                    switch (user_option)
                    {
                        case 1:
                            {
                                HandleAccountOpening newacc = new HandleAccountOpening();
                                var new_user = HandleAccountOpening.CreateUserAccount();
                                if (new_user != null)
                                {
                                    if (dictionaryOfUsers.ContainsKey(new_user.user_id))
                                    {
                                        Console.WriteLine("Account already exists");
                                    }
                                    else
                                    {
                                        dictionaryOfUsers.Add(new_user.user_id, new_user);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("User creation failed try again");
                                }
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Key in user id");
                                string new_user = Console.ReadLine();
                                if (dictionaryOfUsers.ContainsKey(new_user))
                                {
                                    dictionaryOfUsers.Remove(new_user);
                                    Console.WriteLine("ID: " + new_user + " has been removed");
                                }
                                else
                                {
                                    Console.WriteLine("Account doesn't exist");
                                }

                                break;
                            }
                        case 3:
                            {
                                foreach (var item in dictionaryOfUsers)
                                {
                                    Console.WriteLine("{0} > {1}", item.Key, item.Value);
                                }
                                Console.WriteLine(" Viewing all users here");
                                var user_id = Console.ReadLine();
                                var user = dictionaryOfUsers[user_id];

                                dictionaryOfUsers[user_id] = user;
                                break;
                            }
                        case 4:
                            {
                                HandleAccountOpening.UserLogin();
                                Admin.TaskAssigned();
                                break;
                            }
                        case 5:
                            {
                                user_exited = true;
                                break;
                            }
                    }

                }
                catch
                {
                }

            }
            Console.WriteLine("Exiting the program");
        }
        public static void ListAllUsers()
        {
            foreach (var item in dictionaryOfUsers)
            {
                Console.WriteLine("{0} > {1}", item.Key, item.Value);
            }
            Console.WriteLine(" Viewing all users here");
        }
        private void WriteAllTransactionInFile()
        {
            throw new NotImplementedException();
            // override existing file
            // write content of dict in file
        }
    }
}
