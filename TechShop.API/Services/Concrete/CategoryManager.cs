using AutoMapper;
using TechShop.DataAccess.Entities;
using TechShop.DataAccess.Repositories;
using TechShop.DTO;
using TechShop.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        public CategoryManager(IRepository<Category> CategoryRepository)
        {
            this.CategoryRepository = CategoryRepository;
            var MapperConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CategoryCreateDto,Category>();
                c.CreateMap<CategoryDto, Category>().ReverseMap();
            });
            Mapper = MapperConfig.CreateMapper();
        }
        public IMapper Mapper { get; set; }

        public IRepository<Category> CategoryRepository { get; }

        public async Task<(bool res, int id)> CreateCategoryAsync(CategoryCreateDto Category)
        {
            var entity = Mapper.Map<Category>(Category);
            var result = await CategoryRepository.CreateAsync(entity);
            int id = entity.Id;
            return (result, id);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var entity = Mapper.Map<Category>(new CategoryDto());
            var result = await CategoryRepository.DeleteAsync(entity);
            return result;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var list = await CategoryRepository.GetAllAsync();
            var dtos = Mapper.Map<List<CategoryDto>>(list);
            return dtos;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await CategoryRepository.GetByIdAsync(id);
            var dto = Mapper.Map<CategoryDto>(category);
            return dto;
        }

        public async Task<bool> UpdateCategoryAsync(CategoryDto Category)
        {
            var entity = Mapper.Map<Category>(Category);
            var result = await CategoryRepository.UpdateAsync(entity);
            return result;
        }
    }
}
