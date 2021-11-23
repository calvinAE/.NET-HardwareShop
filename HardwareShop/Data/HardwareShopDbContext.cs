using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardwareShop.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareShop.Data
{
    public class HardwareShopDbContext : DbContext
    {
        public HardwareShopDbContext (DbContextOptions<HardwareShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<HardwareShop.Models.ProductCategory> ProductCategory { get; set; }

        public DbSet<HardwareShop.Models.Product> Product { get; set; }
    }
}
