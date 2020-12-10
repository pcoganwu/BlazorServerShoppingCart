using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BlazorServerShoppingCart.Models.Domain
{
    public partial class State
    {
        public State()
        {
            Customers = new HashSet<Customer>();
        }

        [Required, MaxLength(2), Display(Name = "State Code")]
        public string StateCode { get; set; }
        [Required, MaxLength(20), Display(Name = "State Name")]
        public string StateName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
