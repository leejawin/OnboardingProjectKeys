using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnboardingProjectKeys.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [Range(2,50)]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        [Display(Name = "Customer Address")]
        public string Address { get; set; }
      public virtual List<ProductSold> ProductSolds { get; set; }
       // public virtual ICollection<ProductSold> ProductSolds { get; set; }
    }
}