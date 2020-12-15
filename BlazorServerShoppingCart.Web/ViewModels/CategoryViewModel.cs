using BlazorServerShoppingCart.Models.Domain;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.ViewModels
{
    public class CategoryViewModel : ICategoryViewModel
    {
        private readonly HttpClient _httpClient;

        public CategoryViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IList<Category>> GetAllCategories()
        {
            return await _httpClient.GetJsonAsync<List<Category>>("api/categories");
        }
    }
}
