using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Assignment4.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime  Date { get; set; }
        public DateTime?  Required { get; set; }
        public DateTime?  Shipped { get; set; }        
        public int Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }

        public Order()
        {
            Date = new DateTime();
            Required = new DateTime();
            Shipped = new DateTime();
        }
        public List<OrderDetails> OrderDetails { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}, Name : {Date}";
        }
    }
}