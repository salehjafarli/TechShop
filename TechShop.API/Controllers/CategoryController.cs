using TechShop.DTO;
using TechShop.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryController(ICategoryService CategoryService)
        {
            this.CategoryService = CategoryService;
        }

        public ICategoryService CategoryService { get; }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await CategoryService.GetAllCategoriesAsync();
            return Ok(products);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await CategoryService.GetCategoryByIdAsync(id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto Dto)
        {
            var result = await CategoryService.CreateCategoryAsync(Dto);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto Dto)
        {
            var product = await CategoryService.UpdateCategoryAsync(Dto);
            return Ok(product);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await CategoryService.DeleteCategoryAsync(id);
            return Ok(product);
        }
    }
}
