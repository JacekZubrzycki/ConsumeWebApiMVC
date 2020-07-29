using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ConsumeWebApi.Models
{
    public class OrderTotal
    {
        [Display(Name = "Table Number"), JsonProperty("tableNo")] 
        public string tableNo { get; set; }

        [JsonProperty("orderID")] public string id { get; set; }

        [Display(Name = "Total Price"), JsonProperty("totalPrice")] 
        public double totalPrice { get; set; }

        [Display(Name = "Date"), JsonProperty("date")] 
        public string date { get; set; }
    }
}