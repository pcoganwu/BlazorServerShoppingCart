using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorServerShoppingCart.Models.Domain
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Required, MaxLength(10), Display(Name = "Category ID")]
        public string CategoryId { get; set; }
        [Required, MaxLength(15), Display(Name = "Short Name")]
        public string ShortName { get; set; }
        [Required, MaxLength(50), Display(Name = "Long Name")]
        public string LongName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
