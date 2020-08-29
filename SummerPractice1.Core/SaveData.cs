using System.Collections.Generic;

namespace SummerPractice1.Core
{
    public class SaveData
    {
        public List<Product> Products { get; }
        public List<OrderSave> Orders { get; }

        // public SaveData()
        // {
        //     Products = new List<Product>();
        //     Orders = new List<OrderSave>();
        // }
        public SaveData(List<Product> products, List<OrderSave> orders)
        {
            Products = products;
            Orders = orders;
        }
    }
}