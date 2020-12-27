using BlazorServerShoppingCart.Models.Domain;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.ViewModels
{
    public class StateViewModel : IStateViewModel
    {
        private readonly HttpClient _httpClient;

        public StateViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Required, MaxLength(2), Display(Name = "State Code")]
        public string StateCode { get; set; }
        [Required, MaxLength(20), Display(Name = "State Name")]
        public string StateName { get; set; }
        public ICollection<Customer> Customers { get; set; }

        public async Task<IList<State>> GetAllStates()
        {
            return await _httpClient.GetJsonAsync<List<State>>("api/states");
        }

        public async Task<State> GetState(string stateCode)
        {
            return await _httpClient.GetJsonAsync<State>($"api/states/{stateCode}");
        }
    }
}
