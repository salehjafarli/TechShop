using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.DataAccess.Entities
{
    public class Category
    {
        [Column("category_id")]
        public int Id { get; set; }
        [Column("category_name")]
        public string Name { get; set; }
        [Column("category_isdeleted")]
        public bool Isdeleted { get; set; }
    }
}
