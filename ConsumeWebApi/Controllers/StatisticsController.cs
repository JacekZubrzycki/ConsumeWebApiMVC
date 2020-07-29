using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using ConsumeWebApi.Models;
using Newtonsoft.Json;

namespace ConsumeWebApi.Controllers
{
    public class StatisticsController : Controller
    {
    private readonly string baseUrl = "http://localhost:8080/api/";

    public ActionResult MainLog()
    {
        return View();
    }
    
    
    
        public ActionResult ItemsLog()
        {
            IEnumerable<QuantityLog> items = new List<QuantityLog>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("logs/LogQuantityBought");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<IEnumerable<QuantityLog>>(readTask);
                }

                return View(items);
            }
        }
        
        public ActionResult Overall()
        {
            IEnumerable<OrdersLog> orders = new List<OrdersLog>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("logs/Log");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    orders = JsonConvert.DeserializeObject<IEnumerable<OrdersLog>>(readTask);
                }

                return View(orders);
            }
        }
        public ActionResult IncomeLog()
        {
            IEnumerable<Income> incomes = new List<Income>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("logs/Income");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    incomes = JsonConvert.DeserializeObject<IEnumerable<Income>>(readTask);
                }

               
                return View(incomes);
            }
        }
        
    }
}