using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ConsumeWebApi.Models;

namespace ConsumeWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
    public ActionResult GetItems()
    {
        IEnumerable<Item> items = null;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:8080/api/item");

            var responseTask = client.GetAsync("item");
            responseTask.Wait();

            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Item>>();
                readTask.Wait();

                items = readTask.Result;
            }
            else
            {
                items = Enumerable.Empty<Item>();

                ModelState.AddModelError(string.Empty, "Server error try after some time");
            }
        }
        return View(items);
    }
    var responseTask = client.GetAsync("item");
}