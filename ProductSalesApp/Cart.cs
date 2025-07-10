using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSalesApp
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public int TotalItems
        {
            get
            {
                int total = 0;
                foreach (var item in Items)
                {
                    total += item.Quantity;
                }
                return total;
            }
        }
        public decimal TotalAmount
        {
            get
            {
                decimal total = 0;
                foreach (var item in Items)
                {
                    total += item.TotalPrice;
                }
                return total;
            }
        }

        public void AddItem(Product product, int quantity)
        {
            if (product.Quantity < quantity)
            {
                Console.WriteLine("Not enough stock for this product.");
                Console.ReadKey();
                return;
            }
            product.Quantity -= quantity;

            var existingItem = Items.Find(i => i.Name == product.Name);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                CartItem newItem = new CartItem
                {
                    Name = product.Name,
                    Quantity = quantity,
                    UnitPrice = product.UnitPrice,
                };
                Items.Add(newItem);
            }
        }

        public void Clear()
        {
            Items.Clear();
        }

        public void PrintSummary()
        {
            Console.WriteLine("==== Sale Summary ====\n");

            foreach (var item in Items)
            {
                Console.WriteLine($"{item.Name} - Quantity: {item.Quantity}, Unit Price: {item.UnitPrice} TL, Total: {item.TotalPrice} TL");
            }

            Console.WriteLine("\n----------------------");
            Console.WriteLine($"Total Items: {TotalItems}");
            Console.WriteLine($"Total Amount: {TotalAmount} TL");

        }
    }
}
