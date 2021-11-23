using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareShop.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryID { get; set; }

        [Display(Name = "Category name")]
        [Required(ErrorMessage ="Please enter a category name")]
        public string CategoryName { get; set; }


        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}
