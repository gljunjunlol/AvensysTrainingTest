using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace StockAndBillingSoftware
{
    class Supplier
    {
        public static async void SupplierList()
        {
            Random rand = new Random();

            var tasks = Enumerable.Range(1, 5).Select(n => Task.Run(() =>
            {
                Console.WriteLine($"In Task {n}");
                Thread.Sleep(rand.Next(1000, 10000));
                return n;
            }));

            await Task.WhenAll(tasks.ToArray());            // multiple tasks
            Console.WriteLine("All tasks completed");
            Console.WriteLine("Supplier has supplied");
        }
    }
}
