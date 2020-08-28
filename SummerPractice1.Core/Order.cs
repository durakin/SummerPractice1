using System;
using System.Collections.Generic;

namespace SummerPractice1.Core
{
    public class Order
    {
        public List<Product> Content { get; set; }
        public DateTime OrderDate { get; set; }
        public string Owner { get; set; }
        public DateTime ShipmentDate { get; set; }

        public override string ToString() =>
            $"Owner: {Owner}\nDate of order: {OrderDate}\nDate of shipment: {ShipmentDate}\n";

        public List<Product> AllProducts() => Content;
    }
}