using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorEvent
{
    public delegate void DelPasswordGenerator(bool b);
    class PassWord
    {
        public event DelPasswordGenerator PassWordEx;

        public void performOperation(bool b)
        {
            if (PassWordEx != null)
            {
                PassWordEx.Invoke(b);
            }
        }
        public bool ValidatePassword(string passWord)
        {
            int validConditions = 0;

            foreach (char c in passWord)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in passWord)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            int count = 0;
            foreach (char c in passWord)
            {
                count++;
                if (count >= 6 && count <= 24)
                {
                    validConditions = 3;
                    break;
                }
            }
            if (validConditions == 0) return false;
            foreach (char c in passWord)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            
            if (validConditions == 1) return false;
            if (validConditions == 3) return false;
            if (validConditions == 2)
            {
                char[] special = { '!', '@', '#', '$', '^', '&', '*', '(', ')', '+', '=', '_', '-', '{', '}', '[', ']', ':', ';', '"', '?', '<', '>', ',', '.' };
                if (passWord.IndexOfAny(special) == -1) return false;
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] passWords = { "1111", "sed2T3210", "*v3X123456", "Ae234&B", "fg234", "g1HL", "#1$23", "5a7%123" };
            PassWord password = new PassWord();
            password.PassWordEx += Password_PassWordEx;


            foreach (string passWord in passWords)
            {

                bool b = password.ValidatePassword(passWord);
                Console.WriteLine("'{0}' is{1} a valid password", passWord, b ? "" : " NOT");
            }
            Console.ReadKey();
        }

        private static void Password_PassWordEx(bool b)
        {
            Console.WriteLine("Calculated");
        }
    }
}
