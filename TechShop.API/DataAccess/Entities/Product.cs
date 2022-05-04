using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.DataAccess.Entities
{
    public class Product
    {
        [Column("product_id")]
        public int Id { get; set; }
        [Column("product_name")]
        public string Name { get; set; }
        [Column("product_value")]
        public double Value { get; set; }
        [Column("product_categoryid")]
        public int  CategoryId { get; set; }
        [Column("product_isdeleted")]
        public bool Isdeleted { get; set; }

        public Category Category { get; set; }
    }
}
