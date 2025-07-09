using System;
using System.Collections.Generic;

namespace ProductSales2
{
    class Program
    {
        static List<Product> products = new List<Product>
        {
            new Product { Barcode = "1001", Name = "Bread", Quantity = 50, UnitPrice = 5.00m},
            new Product { Barcode = "1002", Name = "Milk", Quantity = 30, UnitPrice = 10.00m},
            new Product { Barcode = "1003", Name = "Cheese", Quantity = 20, UnitPrice = 20.00m},
            new Product { Barcode ="1004", Name = "Coke", Quantity = 63, UnitPrice = 8.00m}
        };

        static void Main(string[] args)
        {
            while (true)
            {
                ProcessSale();
            }
        }

        static void ProcessSale()
        {
            Cart cart = new Cart();

            bool addingProducts = true;

            while (addingProducts)
            {
                Console.Clear();

                Console.WriteLine("Available Products:");
                foreach (var p in products)
                {
                    Console.WriteLine($"Barcode: {p.Barcode}, Name: {p.Name}, Stock: {p.Quantity}, Price: {p.UnitPrice} TL");
                }

                Console.WriteLine("\nEnter product barcode:");
                string barcode = Console.ReadLine();

                Product product = FindProductByBarcode(barcode);

                if (product == null)
                {
                    Console.WriteLine("Product not found. Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }

                int quantity = GetQuantityFromUser();

                cart.AddItem(product, quantity);

                Console.WriteLine("\n1. Add another product");
                Console.WriteLine("2. Complete sale");

                string choice = Console.ReadLine();

                if(choice == "2")
                {
                    addingProducts = false;
                }

            }

            Console.Clear();
            cart.PrintSummary();

            Console.WriteLine("\nConfirm sale? (Y/N)");
            string confirm = Console.ReadLine();

            if (confirm?.ToUpper() == "Y")
            {
                cart.Clear();
                Console.WriteLine("\nSale completed.");

                Console.WriteLine("\nUpdated Product Stocks:");
                foreach (var p in products)
                {
                    Console.WriteLine($"Barcode: {p.Barcode}, Name: {p.Name}, Stock: {p.Quantity}, Price: {p.UnitPrice} TL");
                }

                Console.WriteLine("\nPress any key to start new sale...");
            }
            else
            {
                Console.WriteLine("Sale canceled. Press any key to start new sale...");
            }

            Console.ReadKey();
        }

        static Product FindProductByBarcode(string barcode)
        {
            foreach (var product in products)
            {
                if (product.Barcode == barcode)
                {
                    return product;
                }

            }
            return null;
        }

        static int GetQuantityFromUser()
        {
            Console.WriteLine("Enter quantity:");
            string input = Console.ReadLine();
            int quantity;

            while(!int.TryParse(input, out quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Try again:");
                input = Console.ReadLine();
            }
            return quantity;
        }
    }
}