using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemHotel
{
    class HotelTaxation
    {
        public int roomBooking { get; set; }
        public double taxation { get; set; }

        public List<int> totalRoomBookings = new List<int>();
        public void CalculateTax()
        {
            Console.WriteLine(" Choose room type");
            Console.WriteLine("1. Single");
            Console.WriteLine("2. Double");
            Console.WriteLine("3. King");
            Console.WriteLine("4. Suite");
            int input = Int32.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    {
                        RoomsType single = RoomsType.Single;
                        int val = (int)single;
                        Console.WriteLine("Room value is .." + val);
                        Console.WriteLine("Single room is booked");
                        RoomBooking.singleBooking(1);
                        Console.WriteLine("Total booking for single is " + RoomBooking.singleBook );
                        Console.WriteLine("Total taxation is " + 1 * 100 * 0.10);
                        double taxationSingle = 1 * 100 * 0.10;
                        HotelBilling.single.Add(taxationSingle);
                        break;
                    }
                case 2:
                    {
                        RoomsType double1 = RoomsType.Double;
                        int val = (int)double1;
                        Console.WriteLine("Room value is .." + val);
                        RoomBooking.doubleBooking(1);
                        Console.WriteLine("Total booking for double is " + RoomBooking.doubleBook);
                        Console.WriteLine("Total taxation is " + 1 * 200 * 0.10);
                        double taxationDouble = 1 * 200 * 0.10;
                        HotelBilling.double1.Add(taxationDouble);
                        break;
                    }
                case 3:
                    {
                        RoomsType king = RoomsType.King;
                        int val = (int)king;
                        Console.WriteLine("Room value is .." + val);
                        RoomBooking.kingBooking(1);
                        Console.WriteLine("Total booking for king is " + RoomBooking.kingBook);
                        Console.WriteLine("Total taxation is " + 1 * 300 * 0.10);
                        double taxationKing = 1 * 300 * 0.10;
                        HotelBilling.king.Add(taxationKing);
                        break;
                    }
                case 4:
                    {
                        RoomsType suite = RoomsType.Suite;
                        int val = (int)suite;
                        Console.WriteLine("Room value is .." + val);
                        RoomBooking.suiteBooking(1);
                        Console.WriteLine("Total booking for suite is " + RoomBooking.suiteBook);
                        Console.WriteLine("Total taxation is " + 1 * 400 * 0.10);
                        double taxationSuite = 1 * 400 * 0.10;
                        HotelBilling.suite.Add(taxationSuite);
                        break;
                    }
            }
        }
    }   
}
