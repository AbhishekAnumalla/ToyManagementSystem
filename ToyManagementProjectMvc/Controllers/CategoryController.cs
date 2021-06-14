using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ToyManagementProjectMvc.Helper;
using ToyManagementProjectMvc.Models;

namespace ToyManagementProjectMvc.Controllers
{
    public class CategoryController : Controller
    {
        HelperClass _api = new HelperClass();
        public async Task<IActionResult> Index()
        {
            List<Category> categories = new List<Category>();

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("https://localhost:44307/api/Category");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                categories = JsonConvert.DeserializeObject<List<Category>>(result);
            }
            return View(categories);
        }

        public ActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<Category>("https://localhost:44307/api/Category", category);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Create");
        }

        public async Task<IActionResult> Details(int id)
        {
            Category category = new Category();
            /*List<Category> list = new List<Category>();*/
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("https://localhost:44307/api/Category/" + id);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<Category>(result);
                /*list= JsonConvert.DeserializeObject<List<Film1>>(result);*/
            }
            return View(category);
        }
    }
}
