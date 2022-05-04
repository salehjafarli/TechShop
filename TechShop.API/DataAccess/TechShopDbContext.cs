using TechShop.DataAccess.Entities;
using TechShop.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.DataAccess
{
    public class TechShopDbContext : DbContext
    {
        public TechShopDbContext(DbContextOptions<TechShopDbContext> opts, IConfigurationManager configurationManager) : base(opts)
        {
            ConfigurationManager = configurationManager;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public IConfigurationManager ConfigurationManager { get; }

        protected async override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            dynamic config = await ConfigurationManager.GetConfig();
            string constr = config.ConnectionStrings.mssql;
            optionsBuilder.UseSqlServer(constr);
        }
    }
}
