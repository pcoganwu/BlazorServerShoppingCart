using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorServerShoppingCart.Models.Domain
{
    public partial class Product
    {
        public Product()
        {
            LineItems = new HashSet<LineItem>();
        }

        [Required, MaxLength(10), Display(Name = "Product ID")]
        public string ProductId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(200), Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Required, MaxLength(2000), Display(Name = "Long Description")]
        public string LongDescription { get; set; }
        [Required, MaxLength(10), Display(Name = "Category ID")]
        public string CategoryId { get; set; }
        [MaxLength(400), Display(Name = "Image File")]
        public string ImageFile { get; set; }
        [Required, Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        [Required, Display(Name = "On Hand")]
        public int OnHand { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
