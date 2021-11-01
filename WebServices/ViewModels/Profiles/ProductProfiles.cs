using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Assignment4.Domain;
using WebServices.ViewModels;

namespace WebServices.ViewModels.Profiles{
    
    public class ProductsProfiles : Profile
    {
        public ProductsProfiles()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<CreateProductViewModel, Product>();
        }
    }
}