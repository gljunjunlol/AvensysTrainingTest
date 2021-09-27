using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4
{
    public delegate void calPackage();
    class Package
    {
        public event calPackage CalculatePackage;

        public int trackingNumber { get; set; }

        public string senderName { get; set; }

        public string receiverName { get; set; }

        public string receiverAddress { get; set; }

        public Package(int track, string sender, string receiver, string receiveraddr)
        {
            trackingNumber = track;
            senderName = sender;
            receiverName = receiver;
            receiverAddress = receiveraddr;
        }


        public void Receive()
        {
            PackageManager pk = new PackageManager();
            pk.CalPackageManager += Pk_CalPackageManager;
            pk.Receive();
        }

        private void Pk_CalPackageManager()
        {
            if (CalculatePackage != null)
            {
                CalculatePackage.Invoke();
            }
        }

        public void Dispatched()
        {
            PackageManager pk1 = new PackageManager();
            pk1.CalPackageManager -= Pk1_CalPackageManager;     // unsubscribe
            pk1.Dispatched();
        }

        private void Pk1_CalPackageManager()
        {
            if (CalculatePackage != null)
            {
                CalculatePackage.Invoke();
            }
        }
    }
}
