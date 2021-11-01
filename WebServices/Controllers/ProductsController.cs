using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using Assignment4;
using Assignment4.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebServices.ViewModels;

namespace WebServices.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;
        
        public ProductsController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }
        
        [HttpGet("{id}", Name = nameof(GetProduct))]
        public IActionResult GetProduct(int id)
        {
            var product = _dataService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = CreateProductViewModel(product);
            return Ok(model);
        }
        
        private CategoryViewModel CreateProductViewModel(Product product)
        {
            var model = _mapper.Map<CategoryViewModel>(product);
            model.Url = GetUrl(product);
            return model;
        }
        private string GetUrl(Product product)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetProduct), new { product.Id });
        }
    }
}