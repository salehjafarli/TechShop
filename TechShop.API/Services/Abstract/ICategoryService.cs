using TechShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.Results;

namespace TechShop.Services.Abstract
{
    public interface ICategoryService
    {
        Task<Result<List<CategoryDto>>> GetAllCategoriesAsync();
        Task<Result<CategoryDto>> GetCategoryByIdAsync(int id);
        Task<Result<(bool res, int id)>> CreateCategoryAsync(CategoryCreateDto Category);
        Task<Result<bool>> UpdateCategoryAsync(CategoryDto Category);
        Task<Result<bool>> DeleteCategoryAsync(int id);
    }
}
