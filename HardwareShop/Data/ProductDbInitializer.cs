using HardwareShop.Data;
using HardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace HardwareShop.Models
{
    public abstract class ProductDbInitializer 
    {
        public static void Initialize (HardwareShopDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            if (dbContext.Product.Any())
            {
                return;
            }
       
            var Pcategories = new List<ProductCategory> {
                new ProductCategory
                {
                    CategoryID = 1,
                    CategoryName = "Motherboards",
                },

                 new ProductCategory
                 {
                     CategoryID = 2,
                     CategoryName = "Processors"
                },
                 new ProductCategory
                 {
                     CategoryID = 3,
                     CategoryName = "Graphics cards"

                 },
                 new ProductCategory
                 {
                    CategoryID = 4,
                    CategoryName = "Power supplies"
                 },
                 new ProductCategory
                 {
                    CategoryID = 5,
                    CategoryName = "RAM"
                 }

            };
         
       
            var products = new List<Product> {
                    new Product
                    {
                        ProductID = 1,
                        ProductName = "MSI Tomahawk B450",
                        Description = "Featuring heavy plated heat sinks and fierce looks, MSI ARSENAL GAMING motherboards are packed with gaming features for a refined gaming experience.",
                        ImagePath = "msiB450.jpg",
                        Price = 129.99,
                        CategoryID = 1

                    },
                    new Product
                    {
                        ProductID = 2,
                        ProductName = "AMD Ryzen 3700x",
                        Description = "The AMD Ryzen 7 3700X is a powerful processor from the new Ryzen 3000 series. This CPU is suitable for high-end gaming, as well as photo and video editing. ",
                        ImagePath = "AMDRyzen3700.jpg",
                        Price = 315,
                        CategoryID = 2

                    },
                    new Product
                    {
                        ProductID = 3,
                        ProductName = "Nvidia RTX 3070",
                        Description = "Nvidia's third generation ray tracing card.",
                        ImagePath = "3070",
                        Price = 719,
                        CategoryID = 3

                    }
            };
               
       
        }

   
    }
}
