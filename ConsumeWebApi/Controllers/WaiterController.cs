using System.Web.Mvc;

namespace ConsumeWebApi.Controllers
{
    public class WaiterController : Controller
    {
        public ActionResult GetOrder()
        {
            return View();
        }
    }
}