using System.Collections.Generic;

namespace SummerPractice1.Core
{
    public class Product
    {
        public string Name;
        public int Price;
        public int Weight;

        public Product(string name, int price, int weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public override string ToString()
        {
            return
                $"Product: {Name}\nPrice: {Price}\nWeight: {Weight}\n";
        }

        public List<Order> AllOrders(List<Order> objList)
        {
            var result = new List<Order>();
            foreach (var order in objList)
            {
                if (order.Content.Contains(this))
                {
                    result.Add(order);
                }
            }
            return result;
        }
    }
}