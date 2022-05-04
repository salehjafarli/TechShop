using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.DTO
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public int CategoryId { get; set; }
    }
}
