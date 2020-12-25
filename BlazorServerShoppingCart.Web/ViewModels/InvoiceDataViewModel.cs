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
    public class InvoiceDataViewModel : IInvoiceDataViewModel
    {
        private readonly HttpClient _httpClient;

        public InvoiceDataViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Required, Display(Name = "Sale Tax")]
        public decimal SalesTax { get; set; }

        public async Task<IList<InvoiceDatum>> InvoiceData()
        {
            return await _httpClient.GetJsonAsync<List<InvoiceDatum>>("api/invoicedata");
        }
    }
}
