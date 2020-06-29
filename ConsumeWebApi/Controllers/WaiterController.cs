using System.Web.Mvc;

namespace ConsumeWebApi.Controllers
{
    public class WaiterController : Controller
    {
        private readonly string baseUrl = "http://localhost:8080/api/";
        public ActionResult GetOrder()
        {
            return View();
        }
        
        [HttpGet]
    
        public ActionResult getOrders()
        {
            IEnumerable<Order> orders = new List<Order>();
    
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetAsync("order");
                responseTask.Wait();
        
                var result = responseTask.Result;
        
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<IEnumerable<Order>>(readTask);
                }

                return View(GetOrder);
            }
        }
        
    }
}