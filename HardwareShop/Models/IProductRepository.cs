using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareShop.Models
{
    interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
