using System;
using System.Collections.Generic;

namespace SummerPractice1.Core
{
    public class Order
    {
        public List<Product> Content { get; } = new List<Product>();
        public DateTime OrderDate { get; set; }
        public string Owner { get; set; }
        public DateTime ShipmentDate { get; set; }

        public Order(string owner, DateTime orderDate, DateTime shipmentDate)
        {
            Owner = owner;
            OrderDate = orderDate;
            ShipmentDate = shipmentDate;
        }

        public Order(OrderSave origin, List<Product> products)
        {
            Owner = origin.Owner;
            OrderDate = origin.OrderDate;
            ShipmentDate = origin.ShipmentDate;
            foreach (var i in origin.Products)
            {
                Content.Add(products.Find(u => u.Name == i));
            }
        }
        public override string ToString() =>
            $"Owner: {Owner}\nDate of order: {OrderDate}\nDate of shipment: {ShipmentDate}\n";

        public List<Product> AllProducts() => Content;
    }
}