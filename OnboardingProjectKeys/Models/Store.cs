using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnboardingProjectKeys.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Store Name")]
        [Required]
        public string StoreName { get; set; }
        [Required]
        [Display(Name = "Store Address")]
        public string Address { get; set; }
        public virtual List<ProductSold> ProductSolds { get; set; }
       // public virtual ICollection<ProductSold> ProductSolds { get; set; }
    }
}