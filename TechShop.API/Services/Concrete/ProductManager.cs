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
    public class ProductManager : IProductService
    {
        public ProductManager(IRepository<Product> ProductRepository)
        {
            this.ProductRepository = ProductRepository;
            var MapperConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductCreateDto, Product>();
                c.CreateMap<ProductDto, Product>().ReverseMap();
            });
            Mapper = MapperConfig.CreateMapper();
        }
        public IMapper Mapper { get; set; }

        public IRepository<Product> ProductRepository { get; }

        public async Task<(bool res, int id)> CreateProductAsync(ProductCreateDto Category)
        {
            var entity = Mapper.Map<Product>(Category);
            var result = await ProductRepository.CreateAsync(entity);
            int id = entity.Id;
            return (result, id);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var entity = Mapper.Map<Product>(new ProductDto());
            var result = await ProductRepository.DeleteAsync(entity);
            return result;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var list = await ProductRepository.GetAllAsync();
            var dtos = Mapper.Map<List<ProductDto>>(list);
            return dtos;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var category = await ProductRepository.GetByIdAsync(id);
            var dto = Mapper.Map<ProductDto>(category);
            return dto;
        }

        public async Task<bool> UpdateProductAsync(ProductDto Category)
        {
            var entity = Mapper.Map<Product>(Category);
            var result = await ProductRepository.UpdateAsync(entity);
            return result;
        }
    }
}
