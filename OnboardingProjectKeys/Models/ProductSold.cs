using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnboardingProjectKeys.Models
{
    public class ProductSold
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Product Name")]
        public int ProductId { get; set; }
        [Display(Name = "Customer Name")]
        public int CustomerId { get; set; }
        [Display(Name = "Store Name")]
        public int StoreId { get; set; }
        [Required]
        [Display(Name = "Date Sold")]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public string DateSold { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public Store Store { get; set; }


    }
}