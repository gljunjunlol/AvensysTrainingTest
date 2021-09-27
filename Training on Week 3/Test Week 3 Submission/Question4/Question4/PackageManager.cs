using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4
{
    public delegate void DisplayInventory();
    class PackageManager
    {
        public event DisplayInventory CalPackageManager;

        List<int> packageCount = new List<int>();
        public void Receive()
        {
            
            if (CalPackageManager != null)
            {
                Console.WriteLine("Package added");
                packageCount.Add(1);
                CalPackageManager.Invoke();
            }

        }

        public void Dispatched()
        {
            if (CalPackageManager != null)
            {
                Console.WriteLine("Package dispatch");
                packageCount.Remove(1);
                CalPackageManager.Invoke();
            }
        }

        public void DisplayInformationInventory()
        {
            Console.WriteLine(packageCount); 
        }

    }
}
