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
        private readonly string baseUrl = "http://10.152.196.10:8080/api/";

        public ActionResult Index()
        {
            IEnumerable<OrderTotal> ordersTotal = new List<OrderTotal>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("order");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsStringAsync().Result;
                    ordersTotal = JsonConvert.DeserializeObject<IEnumerable<OrderTotal>>(read);
                }

                return View(ordersTotal);
            }
        }
        [HttpPost]
        [ActionName("PayOrder")]
        public async Task<ActionResult> PayOrder(string Id)
        {
            using (var client = new HttpClient())
            {
                var uri = baseUrl + "order/" + Id;
                Console.WriteLine(uri);
                await client.DeleteAsync(uri);
            }

            return RedirectToAction("Index");
        }
        public ActionResult PayOrder(OrderTotal orders)
        {
            using (var client = new HttpClient())
            {
                OrderTotal toBePaid = null;
                var orderID = orders.orderID;
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("order/byID" + orderID);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    toBePaid = JsonConvert.DeserializeObject<OrderTotal>(readTask);
                }
                var uri = baseUrl + "order/" + orderID;
                Console.WriteLine(uri);

                return View(toBePaid);
            }
        }

       

        [HttpGet]
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

        [HttpPost]
        [ActionName("DeleteItem")]
        public async Task<ActionResult> DeleteItem(string Id)
        {
            using (var client = new HttpClient())
            {
                var uri = baseUrl + "item/" + Id;
                Console.WriteLine(uri);
                await client.DeleteAsync(uri);
            }

            return RedirectToAction("GetItems");
        }

        public ActionResult DeleteItem(Item item)
        {
            using (var client = new HttpClient())
            {
                Item itemForDeletion = null;
                var itemId = item.Id;
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("item/byId/" + itemId);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    itemForDeletion = JsonConvert.DeserializeObject<Item>(readTask);
                }

                return View(itemForDeletion);
            }
        }
    }
}