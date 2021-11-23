using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace HardwareShop.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Product name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter a product description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
      
        [Required(ErrorMessage = "Please enter an image url")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image path")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Please enter a price")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public double Price { get; set; }
      
        [Required]
        public int? CategoryID { get; set; }
      

        public virtual ProductCategory Category { get; set; }
    }
}
