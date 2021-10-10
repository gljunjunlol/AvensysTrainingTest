using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAndBillingSoftware
{
    class Product
    {
        public string productName { get; set; }

        public string productModel { get; set; }
        public decimal productPrice { get; set; }

        //public int productQuantity { get; set; }

        public Product()
        {
            productName = " ";
            productModel = " ";
            productPrice = 0.00M;
        }
        public Product(string name, string model, decimal price)
        {
            productName = name;
            productModel = model;
            productPrice = price;
            //productQuantity = quantity;
        }

        override public string ToString()
        {
            return "Name: " + productName + " Model " + productModel + " Price: $ " + productPrice;
        }
    }
}
