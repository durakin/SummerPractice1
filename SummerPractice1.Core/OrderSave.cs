using System;
using System.Collections.Generic;

namespace SummerPractice1.Core
{
    public class OrderSave
    {
        public DateTime OrderDate { get; set; }
        public string Owner { get; set; }
        public DateTime ShipmentDate { get; set; }

        public List<string> Products { get; } = new List<string>();

        public OrderSave()
        {
            
        }
        public OrderSave(Order origin)
        {
            Owner = origin.Owner;
            OrderDate = origin.OrderDate;
            ShipmentDate = origin.ShipmentDate;
            foreach (var i in origin.Content)
            {
                Products.Add(i.Name);
            }
        }
    }
}