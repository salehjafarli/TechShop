using TechShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.DataAccess.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        public CategoryRepository(TechShopDbContext Context)
        {
            this.Context = Context;
        }

        public TechShopDbContext Context { get; }

        public async Task<bool> CreateAsync(Category entity)
        {
            await Context.Categories.AddAsync(entity);
            var val = await Context.SaveChangesAsync();
            return val == 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await Context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            entity.Isdeleted = true;
            Context.Categories.Update(entity);
            var val = await Context.SaveChangesAsync();
            return val == 1;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await Context.Categories.Where(x => !x.Isdeleted ).ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await Context.Categories.FirstOrDefaultAsync(x => x.Id == id && !x.Isdeleted);
        }

        public async Task<bool> UpdateAsync(Category entity)
        {
            Context.Categories.Update(entity);
            var val = await Context.SaveChangesAsync();
            return val == 1;
        }
    }
}
