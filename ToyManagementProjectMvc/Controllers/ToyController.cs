using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ToyManagementProjectMvc.Helper;
using ToyManagementProjectMvc.Models;

namespace ToyManagementProjectMvc.Controllers
{
    public class ToyController : Controller
    {
        ToyHelperClass _api = new ToyHelperClass();
        public async Task<IActionResult> Index()
        {
            List<Toy> Film1s = new List<Toy>();

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("https://localhost:44307/api/Toy/");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                Film1s = JsonConvert.DeserializeObject<List<Toy>>(result);
            }
            return View(Film1s);
        }


        public async Task<IActionResult> Details(int id)
        {
            Toy toy = new Toy();
            /*List<Category> list = new List<Category>();*/
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("https://localhost:44307/api/Toy/GetToy/" + id);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                toy = JsonConvert.DeserializeObject<Toy>(result);
                /*list= JsonConvert.DeserializeObject<List<Film1>>(result);*/
            }
            return View(toy);
        }

        public ActionResult Create()
        {
            return View(new Toy());
        }
        [HttpPost]
        public ActionResult Create(Toy toy)
        {
            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<Toy>("https://localhost:44307/api/Toy/", toy);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Create");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Toy toy = new Toy();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("/api/Toy/GetToy/" +id);
            if (res.IsSuccessStatusCode)
            {
                /*var result = res.Content.ReadAsStreamAsync().Result.ToString();*/
                var result = res.Content.ReadAsStringAsync().Result;
                toy = JsonConvert.DeserializeObject<Toy>(result);
            }
            return View(toy);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Toy toy)
        {
            HttpClient client = _api.Initial();
            var putTask = await client.PutAsJsonAsync<Toy>("/api/Toy/Put/", toy);
            /*putTask.Wait();*/

            var result = putTask/*.Result*/;
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else
                return View(toy);
        }

        /*  public async Task<ActionResult> Delete(string name)
          {
              Film1 Film1 = new Film1();
              HttpClient client = _api.Initial();
              HttpResponseMessage res = await client.GetAsync("/api/DirectorFilms1/" + name);
              if (res.IsSuccessStatusCode)
              {
                  var result = res.Content.ReadAsStringAsync().Result;
                  Film1 = JsonConvert.DeserializeObject<Film1>(result);
              }
              return View(Film1);
          }*/


        public async Task<IActionResult> Delete(int id)
        {
            /*Film1 Film1 = new Film1();*/
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync("/api/Toy/" + id);
            return RedirectToAction("Index");
        }
    }
}
