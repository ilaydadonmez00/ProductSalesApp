using ProductSalesApp;
using System;
using System.Collections.Generic;


namespace ProductSalesApp
{
    class Program
    {
        static List<Product> products = new List<Product>
        {
         new Product { Barcode = "4001", Name = "Milk (1L)", Quantity = 100, UnitPrice = 25.00m },
         new Product { Barcode = "4002", Name = "Eggs (10 pcs)", Quantity = 80, UnitPrice = 45.00m },
         new Product { Barcode = "4003", Name = "Sugar (1kg)", Quantity = 60, UnitPrice = 50.00m },
         new Product { Barcode = "4004", Name = "Sunflower Oil (1L)", Quantity = 40, UnitPrice = 95.00m },
         new Product { Barcode = "4005", Name = "Pasta (500g)", Quantity = 150, UnitPrice = 20.00m },
         new Product { Barcode = "4006", Name = "Rice (1kg)", Quantity = 90, UnitPrice = 60.00m },
         new Product { Barcode = "4007", Name = "Tea (500g)", Quantity = 70, UnitPrice = 85.00m },
         new Product { Barcode = "4008", Name = "Coffee (100g)", Quantity = 50, UnitPrice = 120.00m },
         new Product { Barcode = "4009", Name = "Biscuits (pack)", Quantity = 200, UnitPrice = 15.00m },
         new Product { Barcode = "4010", Name = "Cheese (250g)", Quantity = 60, UnitPrice = 80.00m },
         new Product { Barcode = "4011", Name = "Apple (kg)", Quantity = 100, UnitPrice = 35.00m },
         new Product { Barcode = "4012", Name = "Banana (kg)", Quantity = 80, UnitPrice = 40.00m },
         new Product { Barcode = "4013", Name = "Tomato (kg)", Quantity = 120, UnitPrice = 25.00m }
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

                Console.WriteLine("Welcome to our supermarket!");
                Console.WriteLine("Enjoy your shopping!\n");

                Console.WriteLine("Available Products:");

                foreach (var p in products)
                {
                    Console.WriteLine($"Barcode: {p.Barcode}, Name: {p.Name}, Stock: {p.Quantity}, Price: {p.UnitPrice} TL");
                }

                Console.WriteLine("\nEnter the product barcode you want to buy:");
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

                Console.WriteLine($"\n{quantity} x {product.Name} has been added to your cart.");

                Console.WriteLine("\n1. Add another product");
                Console.WriteLine("2. Complete sale");

                string choice = Console.ReadLine();

                if (choice == "2")
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
                Console.WriteLine("\nSale completed.\n");
                Console.WriteLine("Updated Product Stocks:");
                foreach (var p in products)
                {
                    Console.WriteLine($"Barcode: {p.Barcode}, Name: {p.Name}, Stock: {p.Quantity}, Price: {p.UnitPrice} TL");
                }
                cart.Clear();
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

            while (!int.TryParse(input, out quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Try again:");
                input = Console.ReadLine();
            }

            return quantity;
        }
    }
}