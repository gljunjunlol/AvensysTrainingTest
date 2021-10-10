using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAndBillingSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            Store s = new Store();
            Console.WriteLine("Welcome to our hardware store. First you must create some hardware inventory.\n Then add some products to the shopping cart");
            Console.WriteLine("Finally you may checkout which give you a total value of the shopping cart");

            int action = chooseAction();

            while (action != 0)
            {

                switch (action)
                {
                    case 1:
                        {
                            Console.WriteLine("You chose to add a new product to the inventory");

                            string productName = "";
                            string productModel = "";
                            decimal productPrice = 0;

                            Console.WriteLine("What is the product name?");
                            productName = Console.ReadLine();

                            Console.WriteLine("What is the product model>");
                            productModel = Console.ReadLine();

                            Console.WriteLine("What is the product price");
                            productPrice = decimal.Parse(Console.ReadLine());

                            Supplier.SupplierList();
                            Product newProduct = new Product(productName, productModel, productPrice);
                            s.ProductList.Add(newProduct);

                            printInventory(s);

                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("List item name to remove");
                            string input = Console.ReadLine();
                            s.ProductList.RemoveAll(r => r.productName==input);
                            Console.WriteLine(input + " has been removed");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("You chose to add a product to shopping cart");
                            printInventory(s);
                            Console.WriteLine("Which item would like you to buy? (number)");
                            int productChosen = Int32.Parse(Console.ReadLine());
                            try
                            {
                                s.ShoppingList.Add(s.ProductList[productChosen]);
                            }
                            catch(ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("out of range");
                            }
                            

                            printShoppingCart(s);

                            break;
                        }
                    case 4:
                        {
                            
                            CustomerManagement.AddCustomer();
                            printShoppingCart(s);
                            Console.WriteLine("The total cost of your items : " + s.Checkout());
                            InvoiceBill.Invoice();
                            break;
                        }
                    case 5:
                        {
                            s.SearchforProduct(s);
                            break;
                        }
                    case 6:
                        {
                            CustomerManagement.ListCustomers();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                action = chooseAction();
            }            
            Console.WriteLine("Exiting the program");
            Console.ReadLine();
        }
        private static void printShoppingCart(Store s)
        {
            Console.WriteLine("Product you have chose to buy");
            for (int i = 0; i < s.ShoppingList.Count; i++)
            {
                Console.WriteLine("Product: " + i + " " + s.ShoppingList[i]);
            }
        }

        private static void printInventory(Store s)
        {
            for(int i = 0; i < s.ProductList.Count; i++)
            {
                Console.WriteLine("Product: " + i + " " +  s.ProductList[i]);
            }
        }

        static public int chooseAction()
        {
            int choice = 0;
            Console.WriteLine("Choose an action (0) exit\n (1) add inventory\n (2) remove inventory\n (3) add product to cart\n (4) Checkout\n (5) Search by product\n (6) Search a customer");
            try
            {
                choice = Int32.Parse(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("wrong format");
            }
            
            return choice;
        }
    }
}
