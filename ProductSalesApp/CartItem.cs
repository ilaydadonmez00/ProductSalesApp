using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSalesApp
{
    public class CartItem
    {
        public string Name { get; set; }
        public int Quantity { set; get; }
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }
    }
}
