using TechShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.DataAccess.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        public ProductRepository(TechShopDbContext Context)
        {
            this.Context = Context;
        }

        public TechShopDbContext Context { get; }

        public async Task<bool> CreateAsync(Product entity)
        {
            await Context.Products.AddAsync(entity);
            var val = await Context.SaveChangesAsync();
            return val == 1;
        }

        public async Task<bool> DeleteAsync(Product entity)
        {
            entity.Isdeleted = true;
            Context.Products.Update(entity);
            var val = await Context.SaveChangesAsync();
            return val == 1;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await Context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await Context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            Context.Products.Update(entity);
            var val = await Context.SaveChangesAsync();
            return val == 1;
        }
    }
}
