using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;
using System.Net;

namespace WebApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        HttpClientController httpClientController = new HttpClientController();
        public async Task<IActionResult> Index(string? name)
        {
            List<Product>? products;
            if (name is not null)
            {
                products = await httpClientController.GetList(name);
            } else
            {
                products = await httpClientController.GetList();
            }
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [HttpPost] 
        public async Task<IActionResult> Index([FromBody] Product product)
        {
            HttpStatusCode statusCode = await httpClientController.Create(product);
            if (statusCode == HttpStatusCode.OK)
            {
                return Created();
            }
            else
            {
                return StatusCode((int)statusCode);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            HttpStatusCode statusCode = await httpClientController.Update(product);
            if (statusCode == HttpStatusCode.OK)
            {
                return Accepted();
            }
            else
            {
                return StatusCode((int)statusCode);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            HttpStatusCode statusCode = await httpClientController.Delete(id);
            if (statusCode == HttpStatusCode.OK)
            {
                return Accepted();
            }
            else
            {
                return StatusCode((int)statusCode);
            }
        }
    }
}
