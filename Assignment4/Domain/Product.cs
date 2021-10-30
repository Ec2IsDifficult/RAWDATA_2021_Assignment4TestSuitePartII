using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4.Domain
{
    public class Product
    {
        public Product()
        {

        }
        public int Id { get; set; }
        public string ProductName { get; set; }
        
        public string Name {
            get { return this.ProductName; }
        }
        
        public double UnitPrice { get; set; }
        
        public string QuantityPerUnit { get; set; }
        
        public int UnitsInStock { get; set; }
        
        //Connection with category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string CategoryName
        {
            get {return Category.CategoryName;}
        }
        
        public override string ToString()
        {
            return $"Id = {Id}, Name = {ProductName}, Category = {Category}";
        }
    }
}