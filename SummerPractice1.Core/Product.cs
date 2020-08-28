using System.Collections.Generic;
using System.Linq;

namespace SummerPractice1.Core
{
    public class Product
    {
        public Product(string name, int price, int weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public string Name { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }

        public override string ToString() => $"Product: {Name}\nPrice: {Price}\nWeight: {Weight}\n";

        public IEnumerable<Order> AllOrders(IEnumerable<Order> objList) =>
            objList.Where(order => order.Content.Contains(this));
    }
}