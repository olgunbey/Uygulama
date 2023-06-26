using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MulakatApp.HttpClientService;
using MulakatApp.Models;

namespace MulakatApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ClientService _clientService;
        public ProductsController(ClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public async Task<IActionResult> categories()
        {
            
            CategoryFeature feature = new CategoryFeature();
            await feature.CategoryDoldurAsync();
            ViewBag.Categories = new SelectList(CategoryFeature.Category, "ID", "CategoryName");
            return View();


        }
        [HttpGet]
        public async Task<IActionResult> categorieslist(int id)
        {
               HttpClient client = new HttpClient();
               Category? categories = CategoryFeature.Category!.FirstOrDefault(x => x.ID == id);
            //Root? root = await client.GetFromJsonAsync<Root>($"https://dummyjson.com/products/category/{categories!.CategoryName}");
         Root? root=  await _clientService.RootClient(categories!.CategoryName!);

            return View(root);
        }
        
    }
}
