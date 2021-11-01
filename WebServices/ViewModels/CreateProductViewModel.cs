using Assignment4.Domain;

namespace WebServices.ViewModels
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public Category Category { get; set; }
    }
}