using TechShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<(bool res, int id)> CreateCategoryAsync(CategoryCreateDto Category);
        Task<bool> UpdateCategoryAsync(CategoryDto Category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
