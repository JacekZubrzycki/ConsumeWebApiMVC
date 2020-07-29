using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using ConsumeWebApi.Models;
using Newtonsoft.Json;

namespace ConsumeWebApi.Controllers
{
    public class HelpDeskController : Controller
    {
        private readonly string baseUrl = "http://localhost:8080/api/";

        public ActionResult HelpDesk()
        {
            IEnumerable<Help> help = new List<Help>();

            using (var client = new  HttpClient())
                
            {
                client.BaseAddress= new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("help/tables");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsStringAsync().Result;
                    help = JsonConvert.DeserializeObject<IEnumerable<Help>>(readTask);
                }

                return View(help);

            }
        }

        public ActionResult Helped(Help help)
        {
            using (var client = new HttpClient())

            {
                var tableNo = help.tableNo;
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var uri = "help/helped/"+tableNo;
              
                var responseTask =  client.GetAsync(uri);
                responseTask.Wait();

            }

            return RedirectToAction("HelpDesk");
        }
      
    }
}
    