using TechShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.Results;

namespace TechShop.Services.Abstract
{
    public interface IProductService
    {
        Task<Result<List<ProductDto>>> GetAllProductsAsync();
        Task<Result<ProductDto>> GetProductByIdAsync(int id);
        Task<Result<(bool res, int id)>> CreateProductAsync(ProductCreateDto Product);
        Task<Result<bool>> UpdateProductAsync(ProductUpdateDto Product);
        Task<Result<bool>> DeleteProductAsync(int id);
    }
}
