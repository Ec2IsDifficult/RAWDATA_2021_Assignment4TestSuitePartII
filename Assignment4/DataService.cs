using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Assignment4.Domain;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public interface IDataService
    {
        public IList<Category> GetCategories();
        public Category GetCategory(int id);
        public Category CreateCategory(String name, String desc);
        public bool DeleteCategory(int id);
        public bool UpdateCategory(int id, string name, string desc);
        public IList<Product> GetProducts();
        public Product GetProduct(int id);
        public IList<Product> GetProductByCategory(int id);
        public IEnumerable<Product> GetProductByName(string searchString);
        public IList<Order> GetOrders();
        public Order GetOrder(int id);
        public IList<OrderDetails> GetOrderDetails();
        public IEnumerable<OrderDetails> GetOrderDetailsByOrderId(int id);
        public IEnumerable<OrderDetails> GetOrderDetailsByProductId(int id);
    }

    public class DataService : IDataService
    {
        private static NorthwindContext _ctx = new NorthwindContext();

        //Category functionality
        public IList<Category> GetCategories()
        {
            return _ctx.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _ctx.Categories.FirstOrDefault(x => x.Id == id);
        }

        public Category CreateCategory(String name, String desc)
        {
            Category newCategory = new Category(GetCategories().Count() + 1, name, desc);
            _ctx.Add(newCategory);
            _ctx.SaveChanges();
            return newCategory;

        }

        public bool DeleteCategory(int id)
        {
            if (_ctx.Categories.Any(o => o.Id == id))
            {
                _ctx.Categories.Remove(_ctx.Categories.Single(x => x.Id == id));
                _ctx.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateCategory(int id, string name, string desc)
        {
            var result = _ctx.Categories.SingleOrDefault(b => b.Id == id);
            if (result != null)
            {
                result.Id = id;
                result.CategoryName = name;
                result.Description = desc;
                _ctx.SaveChanges();
                return true;
            }

            return false;
        }


        //Product functionality implementation
        public IList<Product> GetProducts()
        {
            return _ctx.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return _ctx.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public IList<Product> GetProductByCategory(int id)
        {
            return _ctx.Categories.Include(x => x.ProductsList).FirstOrDefault(x => x.Id == id).ProductsList;
        }

        public IEnumerable<Product> GetProductByName(string searchString)
        {
            return _ctx.Products.Where(x => x.ProductName.Contains(searchString));
        }

        //Order functionality 
        public IList<Order> GetOrders()
        {
            return _ctx.Orders.ToList();
        }

        public Order GetOrder(int id)
        {
            return _ctx.Orders.Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
        }


        //OrderDetails functionality
        public IList<OrderDetails> GetOrderDetails()
        {
            return _ctx.OrderDetails.ToList();
        }

        public IEnumerable<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            return _ctx.OrderDetails.Include(x => x.Product).Where(x => x.OrderId == id);
        }

        public IEnumerable<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            return null;
        }
    }
}
