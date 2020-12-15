using BlazorServerShoppingCart.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.ViewModels
{
    public interface ICategoryViewModel
    {
        Task<IList<Category>> GetAllCategories();
    }
}
