using System;
using System.Collections.Generic;

namespace SummerPractice1.Core
{
    public class Order
    {
        public string Owner;
        public DateTime OrderDate;
        public DateTime ShipmentDate;
        public List<Product> Content;
        
        public override string ToString()
        {
            return
                $"Owner: {Owner}\nDate of order: {OrderDate}\nDate of shipment: {ShipmentDate}\n";
        }

        public List<Product> AllProducts()
        {
            return Content;
        }
    }
}