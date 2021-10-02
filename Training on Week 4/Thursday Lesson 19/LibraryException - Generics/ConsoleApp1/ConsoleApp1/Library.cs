using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LoanBook : ILoanBook
    {
        Dictionary<int, string> stdlist = new Dictionary<int, string>();
        Dictionary<int, int> loanbook = new Dictionary<int, int>();


        public void IssueBook()
        {
            stdlist.Add(5000, "John");
            stdlist.Add(6000, "Sam");
            stdlist.Add(7000, "Mary");

            try
            {
                loanbook.Add(5000, 1000);
                loanbook.Add(6000, 1001);
                loanbook.Add(7000, 1002);       // student already borrowed
                loanbook.Add(7000, 1003);
                loanbook.Add(8000, 1004);       // didnt go through as not student




            }
            catch (ArgumentException)
            {
                foreach (var item in loanbook)
                {
                    Console.WriteLine("{0} > {1}", item.Key, item.Value);
                }
                Console.WriteLine(" Last Student already borrowed");
            }
            foreach (int k in stdlist.Keys)
            {
                if (loanbook.ContainsKey(k))
                {
                    Console.WriteLine(stdlist[k] + " Issued done");
                }
            }



        }
    }
}
