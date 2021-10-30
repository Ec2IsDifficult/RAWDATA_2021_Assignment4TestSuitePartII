using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment4.Domain;
namespace Assignment4.Domain
{
    public class Category
    {
        public Category()
        {
            
        }
        public Category(int id, string categoryName, string description)
        {
            Id = id;
            CategoryName = categoryName;
            Description = description;
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public string Name
        {
            get { return this.CategoryName; }
        }

        public string Description { get; set; }
        
        //Relationship with with Product
        public List<Product> ProductsList { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}, Name : {CategoryName}";
        }
    }
}