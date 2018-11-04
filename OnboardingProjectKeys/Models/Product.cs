using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnboardingProjectKeys.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Product Price")]
        public decimal Price { get; set; }
         public virtual List<ProductSold> ProductSolds { get; set; }
       // public virtual ICollection<ProductSold> ProductSolds { get; set; }
    }
}