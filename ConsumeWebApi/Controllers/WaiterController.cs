using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using ConsumeWebApi.Models;
using Newtonsoft.Json;

namespace ConsumeWebApi.Controllers
{
    public class WaiterController : Controller
    {
        private readonly string baseUrl = "http://localhost:8080/api/";


        [HttpGet]
        public ActionResult getOrder()
        {
            IEnumerable<Order> orders = new List<Order>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("ordereditems/done");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(readTask);
                }

                return View(orders);
            }
        }
        
        public ActionResult Delivered(Order order)
        {
            using (var client = new HttpClient())
            {
                var itemId = order.itemID;
                var tableNo = order.tableNO;
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.DeleteAsync("ordereditems/delivered/" + itemId + "," + tableNo);
                responseTask.Wait();
            }

            return RedirectToAction("GetOrder");

        }
    }
}