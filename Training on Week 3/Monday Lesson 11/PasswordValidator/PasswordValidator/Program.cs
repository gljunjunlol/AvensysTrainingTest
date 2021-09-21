using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {   // Password validator check
            bool valid = true;
            Console.WriteLine("Enter new password: 6 to 24 char, 1 upper, 1 lower, 1 digit, 1 special char ");
            string passWords = Console.ReadLine();
            while (true)
            {
                if (passWords.Length < 6 || passWords.Length > 24)
                {
                    valid = false;
                    Console.WriteLine("Invalid password, Check again for correct length");
                    Console.ReadLine();
                    break;
                }
                if (!passWords.Any(char.IsUpper))
                {
                    valid = false;
                    Console.WriteLine("Invalid password, Check again for any upper");
                    Console.ReadLine();
                    break;
                }
                if (!passWords.Any(char.IsLower))
                {
                    valid = false;
                    Console.WriteLine("Invalid password, Check again for any lower");
                    Console.ReadLine();
                    break;
                }
                if (!passWords.Any(char.IsDigit))
                {
                    valid = false;
                    Console.WriteLine("Invalid password, Check again for any digit");
                    Console.ReadLine();
                    break;
                }
                string[] words = passWords.Split(' ');
                int count = 0;
                foreach (string word in words)
                {
                    if (valid)
                    {
                        if (words.Contains(word))
                            count++;
                        if (count > 2)
                        {
                            valid = false;
                            Console.WriteLine("Invalid password, Check again for duplicate format");
                            Console.ReadLine();
                            break;
                        }
                           
                                }
                            }
                string specialCh = "! @ # $ % ^ & * ( ) + = _ - { } [ ] : ;  ' ? < > , .";
                char[] specialCh1 = specialCh.ToCharArray();
                foreach (char ch in specialCh1)
                {
                    if (passWords.Contains(ch))
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                        Console.WriteLine("Invalid password, Check again for special format");
                        Console.ReadLine();
                        break;
                    }
                }
                Console.WriteLine("Valid Password");
                Console.ReadLine();
                break;
            }
                    
                

                        
                                   
                
                
            }
        }
    }




            
            
            
        
            




