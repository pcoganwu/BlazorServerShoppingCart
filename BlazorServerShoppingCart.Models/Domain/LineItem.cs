using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorServerShoppingCart.Models.Domain
{
    public partial class LineItem
    {
        [Required, Display(Name = "Invoice Number")]
        public int InvoiceNumber { get; set; }
        [Required, MaxLength(10), Display(Name = "Product ID")]
        public string ProductId { get; set; }
        [Required, Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal? Extension { get; set; }

        public virtual Invoice InvoiceNumberNavigation { get; set; }
        public virtual Product Product { get; set; }
    }
}
