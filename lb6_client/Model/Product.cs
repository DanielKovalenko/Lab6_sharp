using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb6_server.Model
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public double SellingPrice { get; set; }

        public Product(string name, int quantity, double purchasePrice, double sellingPrice)
        {
            Name = name;
            Quantity = quantity;
            PurchasePrice = purchasePrice;
            SellingPrice = sellingPrice;
        }
    }
}
