using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAndBillingSoftware
{
    class Store
    {
        public List<Product> ProductList { get; set; }
        public List<Product> ShoppingList { get; set; }


        public Store()
        {
            ProductList = new List<Product>();
            ShoppingList = new List<Product>();
        }

        public decimal Checkout()
        {
            // intialize the total total
            decimal totalCost = 0;
            decimal totalCost1 = 0;

            foreach(var c in ShoppingList)
            {
                totalCost = totalCost + c.productPrice;
                totalCost1 = totalCost * 107 / 100;
                Console.WriteLine("With a profit gain of $" + (c.productPrice * 107 / 100 - c.productPrice));
                decimal profit = c.productPrice * 107 / 100 - c.productPrice;
                

            }
            Console.WriteLine("Total cost of items " + totalCost);
            decimal totalShoppingList = ShoppingList.Sum(item => item.productPrice);
            decimal totalShoppingList1 = totalShoppingList * 107 / 100;
            decimal totalprofit = totalShoppingList1 - totalShoppingList;
            Console.WriteLine("Total profit earned " + totalprofit);

            ShoppingList.Clear();
            return totalCost1;
        }

        public void SearchforProduct(Store s)
        {
            for (int i = 0; i < s.ProductList.Count; i++)
            {
                Console.WriteLine("Product: " + i + " " + s.ProductList[i]);
                Console.WriteLine(ProductList[i].productPrice);


            }
            

            Console.WriteLine("Search for prices between...");
            decimal input1 = decimal.Parse(Console.ReadLine());
            Console.WriteLine(" and..");
            decimal input2 = decimal.Parse(Console.ReadLine());

            foreach (Product c in s.ProductList)
            {
                if (c.productPrice > input1 && c.productPrice < input2)
                {
                    Console.WriteLine("Product name: " + c.productName + " model" + c.productModel + " price" + c.productPrice);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("search any product by name: ");
            string input = Console.ReadLine();
            foreach(Product c in s.ProductList)
            {
                if (c.productName.StartsWith(input))
                {
                    Console.WriteLine("Product name: " + c.productName + " model" + c.productModel + " price" + c.productPrice);
                }
            }
            
        }
    }
}
