using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    [NonController]
    public class HttpClientController
    {
        static HttpClient httpClient = new HttpClient();
        string url = "http://localhost:5218/CRUD/";

        public async Task<List<Product>?> GetList()
        {
            string localUrl = url + "Get/";
            List<Product>? products = new List<Product>();
            var response = await httpClient.GetAsync(localUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                products = await response.Content.ReadFromJsonAsync<List<Product>>();
            }
            return products;
        }
        public async Task<List<Product>?> GetList(string filter)
        {
            string localUrl = url + "GetFiltered/" + filter;
            List<Product>? products = new List<Product>();
            var response = await httpClient.GetAsync(localUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                products = await response.Content.ReadFromJsonAsync<List<Product>>();
            }
            return products;
        }
        public async Task<System.Net.HttpStatusCode> Create(Product product)
        {
            string localUrl = url + "Post/";
            var response = await httpClient.PostAsJsonAsync(localUrl, product);
            return response.StatusCode;
        }
        public async Task<System.Net.HttpStatusCode> Update(Product product)
        {
            string localUrl = url + "Update/";
            var response = await httpClient.PutAsJsonAsync(localUrl, product);
            return response.StatusCode;
        }
        public async Task<System.Net.HttpStatusCode> Delete(Guid id)
        {
            string localUrl = url + "Delete/" + id.ToString("N");
            var response = await httpClient.DeleteAsync(localUrl);
            return response.StatusCode;
        }
    }
}
