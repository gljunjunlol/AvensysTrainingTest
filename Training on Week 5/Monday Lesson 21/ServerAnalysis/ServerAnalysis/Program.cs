using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Server myserver = new Server();
            myserver.UniqueVistors = 100;
            myserver.NumberOfVisits = 100;
            myserver.Pages = 50;
            myserver.Hits = 50;
            myserver.bandwidth = 100.00;

            Console.WriteLine("The Unique vistors is at " + myserver.UniqueVistors);
            Console.WriteLine("The number of vistors is at " + myserver.NumberOfVisits);
            Console.WriteLine("The pages is at " + myserver.Pages);
            Console.WriteLine("The hits is at " + myserver.Hits);
            Console.WriteLine("The bandwidth is at " + myserver.bandwidth);


            Console.WriteLine("Enter Y/N to generate report");
            string input = Console.ReadLine();
            
            if (input == "Y" || input == "y")
            {
                int count = 0;
                Console.WriteLine("Average Unique vistors is at " + 100);
                Console.WriteLine("Average number of vistors is at " + 250);
                Console.WriteLine("Average pages is at " + 20);
                Console.WriteLine("Average hits is at " + 25);
                Console.WriteLine("Average bandwidth is at " + 90);


                if (myserver.UniqueVistors > 100)
                {
                    count++;
                }
                if (myserver.NumberOfVisits > 250)
                {
                    count++;
                }
                if (myserver.Pages > 20)
                {
                    count++;
                }
                if (myserver.Hits > 25)
                {
                    count++;
                }
                if (myserver.bandwidth > 90)
                {
                    count++;
                }

                Console.WriteLine("Your score beats " + count + " categories out of 5");
            }
            else
            {
                Console.WriteLine("Ok have a nice day");
            }
            

            Console.ReadLine();
        }
    }
}
