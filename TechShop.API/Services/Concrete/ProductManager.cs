using AutoMapper;
using TechShop.DataAccess.Entities;
using TechShop.DataAccess.Repositories;
using TechShop.DTO;
using TechShop.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.Results;

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
                c.CreateMap<ProductUpdateDto, Product>();
                c.CreateMap<CategoryDto, Category>().ReverseMap();
                c.CreateMap<ProductDto, Product>().ReverseMap();
            });
            Mapper = MapperConfig.CreateMapper();
        }
        public IMapper Mapper { get; set; }

        public IRepository<Product> ProductRepository { get; }

        public async Task<Result<(bool res, int id)>> CreateProductAsync(ProductCreateDto Category)
        {
            var entity = Mapper.Map<Product>(Category);
            var result = await ProductRepository.CreateAsync(entity);
            int id = entity.Id;
            return new SuccessResult<(bool res, int id)>((result, id));
        }

        public async Task<Result<bool>> DeleteProductAsync(int id)
        {
            var result = await ProductRepository.DeleteAsync(id);
            return new SuccessResult<bool>(result);
        }

        public async Task<Result<List<ProductDto>>> GetAllProductsAsync()
        {
            var list = await ProductRepository.GetAllAsync();
            var dtos = Mapper.Map<List<ProductDto>>(list);
            return new SuccessResult<List<ProductDto>>(dtos);
        }

        public async Task<Result<ProductDto>> GetProductByIdAsync(int id)
        {
            var category = await ProductRepository.GetByIdAsync(id);
            var dto = Mapper.Map<ProductDto>(category);
            return new SuccessResult<ProductDto>(dto);
        }

        public async Task<Result<bool>> UpdateProductAsync(ProductUpdateDto Category)
        {
            var entity = Mapper.Map<Product>(Category);
            var result = await ProductRepository.UpdateAsync(entity);
            return new SuccessResult<bool>(result);
        }
    }
}
