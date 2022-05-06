using TechShop.DTO;
using TechShop.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAll()
        {
            var products = await ProductService.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto Dto)
        {
            var result = await ProductService.CreateProductAsync(Dto);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductDto Dto)
        {
            var product = await ProductService.UpdateProductAsync(Dto);
            return Ok(product);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await ProductService.DeleteProductAsync(id);
            return Ok(product);
        }
    }
}
