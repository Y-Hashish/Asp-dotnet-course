using System;
using System.Collections.Generic;
using System.Text;

namespace Day4
{
    internal class Product
    {
        public string ProductName { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductSupplier { get; set; }
        private decimal Price;
        private int quantity;
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value >= 0)
                    quantity = value;
                else
                    quantity = 0;
            }
        }
        public void SetPrice(decimal price)
        {
            if (price > 0)
                Price = price;
            else
                Price = 0;
        }
        public decimal GetPrice()
        {
            return Price;
        }
        public decimal InventoryValue
        {
            get { return Price * Quantity; }
        }
        

        public Product(string productName, string productBarcode, string productSupplier, decimal price, int Quantity)
        {
            ProductName = productName;
            ProductBarcode = productBarcode;
            ProductSupplier = productSupplier;
            if(price>0)
                Price = price;
            else
                price = 0;
            this.Quantity = Quantity;

        }
        public void Display()
        {
            Console.WriteLine($"product name : {this.ProductName} \nproduct barcode : {this.ProductBarcode}\nproduct supplier : {this.ProductSupplier}" +
                $"\nprice : {this.Price}$\nQuantity : {this.Quantity}\ninventory value {this.InventoryValue}");
        }
    }
}
