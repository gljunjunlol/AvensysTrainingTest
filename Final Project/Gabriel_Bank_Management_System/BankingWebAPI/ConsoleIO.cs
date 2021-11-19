﻿using BankingWebAPI.Interfaces;
//using Gabriel_Bank_Management_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWebAPI
{
    public class ConsoleIO : IConsoleIO
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }
    }
}
