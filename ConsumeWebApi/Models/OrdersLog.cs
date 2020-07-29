using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ConsumeWebApi.Models
{
    public class OrdersLog
    {
        [Display(Name = "Table Number"), JsonProperty("tableNO_log")] public string tableNo { get; set; }
        [JsonProperty("orderID_log")] public int orderID { get; set; }
        [Display(Name = "List of Items"), JsonProperty("listOfOrders_log")] public string listOfOrders { get; set; }
        [Display(Name = "Total Price"), JsonProperty("totalPrice_log")] public double totalPrice { get; set; }
        [Display(Name = "Date"), JsonProperty("date_log")] public string timestamp { get; set; }
    }
}