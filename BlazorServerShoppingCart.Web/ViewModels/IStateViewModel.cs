using BlazorServerShoppingCart.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.ViewModels
{
    public interface IStateViewModel
    {
        string StateCode { get; set; }
        string StateName { get; set; }

        ICollection<Customer> Customers { get; set; }

        Task<IList<State>> GetAllStates();
        Task<State> GetState(string stateCode);
    }
}
