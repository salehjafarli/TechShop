using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.DTO
{
    public class CategoryDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
