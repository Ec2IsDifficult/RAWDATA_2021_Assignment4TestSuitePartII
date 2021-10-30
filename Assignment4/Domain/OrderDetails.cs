using System.ComponentModel.DataAnnotations;

namespace Assignment4.Domain
{
    public class OrderDetails
    {
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        
        //Relationship with order
        public int OrderId { get; set; }
        public Order Order { get; set; }
        
        //Relationship with product
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public override string ToString()
        {
            return $"Id : {OrderId}, Name : {ProductId}";
        }
    }
}