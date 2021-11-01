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
using WebServices.ViewModels.WebServices.ViewModels;

namespace WebServices.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public CategoriesController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _dataService.GetCategories();
            var model = categories.Select(CreateCategoryViewModel);
            return Ok(model);
        }
        
        [HttpGet("{id}", Name = nameof(GetCategory))]
        public IActionResult GetCategory(int id)
        {
            var category = _dataService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            var model = CreateCategoryViewModel(category);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryViewModel newCategory)
        {
            var category = _dataService.CreateCategory(newCategory.Name, newCategory.Description);
            var model = CreateCategoryViewModel(category);
            return Created(model.Url, model);
        }
 
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryViewModel updatedCategory)
        {
            _dataService.UpdateCategory(id, updatedCategory.Name, updatedCategory.Description);
            return Ok();
        }
        
        private CategoryViewModel CreateCategoryViewModel(Category category)
        {
            var model = _mapper.Map<CategoryViewModel>(category);
            model.Url = GetUrl(category);
            return model;
        }
        private string GetUrl(Category category)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetCategory), new { category.Id });
        }
    }
}