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
    public class ProductController : ControllerBase
    {
        public ProductController(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        public IProductService ProductService { get; }


        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAll()
        {
            var products = await ProductService.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(ProductCreateDto Dto)
        {
            var result = await ProductService.CreateProductAsync(Dto);
            return Ok(result.id);
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(ProductDto Dto)
        {
            var product = await ProductService.UpdateProductAsync(Dto);
            return Ok(product);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int productId)
        {
            var product = await ProductService.DeleteProductAsync(productId);
            return Ok(product);
        }
    }
}
