using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorServerShoppingCart.Models.Domain
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        [Required, MaxLength(25)]
        public string Email { get; set; }
        [Required, MaxLength(20), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, MaxLength(20), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MaxLength(40)]
        public string Address { get; set; }
        [Required, MaxLength(30)]
        public string City { get; set; }
        [Required, MaxLength(2)]
        public string State { get; set; }
        [Required, MaxLength(9), Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Required, MaxLength(20), Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public virtual State StateNavigation { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
