using Assignment4.Domain;

namespace WebServices.ViewModels
{
    public class ProductViewModel
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public Category Category { get; set; }
    }
}