using TechShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Services.Abstract
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<(bool res, int id)> CreateProductAsync(ProductCreateDto Product);
        Task<bool> UpdateProductAsync(ProductDto Product);
        Task<bool> DeleteProductAsync(int id);
    }
}
