using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorServerShoppingCart.Models.Domain
{
    public partial class InvoiceDatum
    {
        [Required, Display(Name = "Sale Tax")]
        public decimal SalesTax { get; set; }
    }
}
