﻿using TechShop.DataAccess.Entities;
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

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await Context.Products.FirstOrDefaultAsync(x => x.Id == id);
            entity.Isdeleted = true;
            Context.Products.Update(entity);
            var val = await Context.SaveChangesAsync();
            return val == 1;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await Context.Products.Include(p => p.Category).Where(x => !x.Isdeleted ).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await Context.Products.Include(p => p.Category).FirstOrDefaultAsync(x => x.Id == id && !x.Isdeleted);
        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            Context.Products.Update(entity);
            var val = await Context.SaveChangesAsync();
            return val == 1;
        }
    }
}
