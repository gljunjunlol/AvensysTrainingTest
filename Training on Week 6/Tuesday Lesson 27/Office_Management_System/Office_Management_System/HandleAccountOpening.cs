using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office_Management_System
{
    class HandleAccountOpening
    {
        public static string DeleteUserAccount(string user_id)
        {
            Console.WriteLine("Key in user id");
            string id = Console.ReadLine();
            return id;

        }
        public static User CreateUserAccount()
        {
            Console.WriteLine("Key in user id");
            string user_id = Console.ReadLine();

            Console.WriteLine("Key in user name");
            string user_name = Console.ReadLine();

            Console.WriteLine("Key in user pw");
            Console.WriteLine("Password requirements: 1 lower, 1 upper, 1 digit, 6 - 24 chars:");
            string user_pw = Console.ReadLine();

            Console.WriteLine("Key in user email");
            string user_email = Console.ReadLine();


            int validConditions = 0;

            foreach (char c in user_pw)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in user_pw)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            int count = 0;
            foreach (char c in user_pw)
            {
                count++;
                if (count >= 6 && count <= 24)
                {
                    validConditions++;
                    break;
                }
            }
            
            foreach (char c in user_pw)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 0 || validConditions == 1 || validConditions == 2 || validConditions == 3)
            {
                Console.WriteLine("password not met");
            }
            else
            {
                Console.WriteLine("password is ok");
                var new_user = new User(user_id, user_name, user_pw, user_email);
                return new_user;
            }
            return null;
            



            // form -> data validation
            //create customer
            // return new customer
        }

        public static void UserLogin()
        {
            bool exit = false;
            int numberofTries = 4;
            int input = 0;
            while (!exit)
            {
                input++;
                numberofTries--;
                Console.WriteLine("Enter login id " + " (" + "number of tries left " + numberofTries + " )");
                string user_id = Console.ReadLine();
                Console.WriteLine("and pw");
                string user_pw = Console.ReadLine();
                if (SuperAdmin.dictionaryOfUsers.ContainsKey(user_id) && SuperAdmin.dictionaryOfUsers[user_id].user_pw == user_pw)
                {
                    Console.WriteLine($"Congratulations, {SuperAdmin.dictionaryOfUsers[user_id].user_name}, you are now logged in!");
                    Console.WriteLine("ok user found");
                    Console.WriteLine($"Hello your info: { SuperAdmin.dictionaryOfUsers[user_id].user_id} { SuperAdmin.dictionaryOfUsers[user_id].user_name} { SuperAdmin.dictionaryOfUsers[user_id].user_email} { SuperAdmin.dictionaryOfUsers[user_id].task_assigned}");
                    
                    // user first time reading the file
                    string text = "ID " + user_id + ".txt";
                    FileStream fs = new FileStream(text, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    Console.WriteLine("Printing content of text file");
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);   // read from start, beginning of file
                    string str = sr.ReadToEnd();   // if use ReadtoEnd then dont need while loop
                    Console.WriteLine(str);
                    //while (str != null)
                    //{
                    //    Console.WriteLine(str);
                    //    str = sr.ReadLine();
                    //}
                    sr.Close();
                    fs.Close();

                    // user is writing detailed report in the file
                    FileStream fs1 = new FileStream(text, FileMode.Append, FileAccess.Write);
                    StreamWriter streamWriter = new StreamWriter(fs1);

                    Console.WriteLine("Write your detailed report on your task here: ");
                    string report = Console.ReadLine();



                    streamWriter.WriteLine(report);
                    streamWriter.Flush();
                    streamWriter.Close();
                    fs1.Close();

                    // user is reading the file again after written detailed report
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


                    Console.ReadLine();
                    exit = true;
                }
                //if (SuperAdmin.dictionaryOfUsers.TryGetValue(user_id, out user_pw))
                //{
                //    Console.WriteLine("ok pass");
                //}
                else
                {
                    Console.WriteLine("Incorrect user or pw");
                }
                if (input > 3)
                {
                    Console.WriteLine("Too many tries, please wait 5 mins");

                    Console.ReadLine();
                    exit = true;
                }
                if (numberofTries == 0)
                {
                    numberofTries = 4;
                }
            }
            
        }
    }
}
