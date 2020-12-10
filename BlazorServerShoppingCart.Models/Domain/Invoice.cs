using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorServerShoppingCart.Models.Domain
{
    public partial class Invoice
    {
        public Invoice()
        {
            LineItems = new HashSet<LineItem>();
        }

        [Display(Name = "Invoice Number")]
        public int InvoiceNumber { get; set; }
        [Required, MaxLength(25), Display(Name = "Email")]
        public string CustEmail { get; set; }
        [Required, Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [Required, Display(Name = "Sub Total")]
        public decimal Subtotal { get; set; }
        [Required, MaxLength(50), Display(Name = "Ship Method")]
        public string ShipMethod { get; set; }
        [Required, Display(Name = "Shipping Cost")]
        public decimal Shipping { get; set; }
        [Required, Display(Name = "Sale Tax")]
        public decimal SalesTax { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required, MaxLength(10), Display(Name = "Credit Card")]
        public string CreditCardType { get; set; }
        [Required, MaxLength(20), Display(Name = "Card Number")]
        public string CardNumber { get; set; }
        [Required, Display(Name = "Expiration Month")]
        public short ExpirationMonth { get; set; }
        [Required, Display(Name = "Expiration Year")]
        public short ExpirationYear { get; set; }

        public virtual Customer CustEmailNavigation { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
