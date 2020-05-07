using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ConsumeWebApi.Models;
using Newtonsoft.Json;

namespace ConsumeWebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly string baseUrl = "http://localhost:8080/api/";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetItems()
        {
            IEnumerable<Item> items = new List<Item>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("item");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<IEnumerable<Item>>(readTask);
                }

                return View(items);
            }
        }
        [HttpPost]
        [ActionName("additem")]
        public async Task<ActionResult> AddItem(Item item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);


                var jsonString = JsonConvert.SerializeObject(item);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                await client.PostAsync("item", content);
            }
            return RedirectToAction("GetItems");
        }

        public ActionResult AddItem()
        {
            return View();
        }
    }

}

