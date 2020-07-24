﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using ConsumeWebApi.Models;
using Newtonsoft.Json;

namespace ConsumeWebApi.Controllers
{
    public class KitchenController : Controller
    {
        private readonly string baseUrl = "http://localhost:8080/api/";


        [HttpGet]
        public ActionResult seeOrder()
        {
            IEnumerable<Order> orders = new List<Order>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("ordereditems/undone");
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
        
        public ActionResult Done(Order order)
        {
            using (var client = new HttpClient())
            {
                Order itemAsDone = null;
                var itemId = order.itemID;
                var tableNo = order.tableNO;
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("ordereditems/done/" + itemId + "," + tableNo);
                responseTask.Wait();
                var result = responseTask.Result;
                
                var uri = baseUrl + "ordereditems/done/" + itemId + "," + tableNo;
                Console.WriteLine(uri);
                
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    itemAsDone = JsonConvert.DeserializeObject<Order>(readTask);
                }

               
            }

            return RedirectToAction("SeeOrder");

        }
        
        
    }
}