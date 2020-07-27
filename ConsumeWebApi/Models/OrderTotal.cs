using Newtonsoft.Json;

namespace ConsumeWebApi.Models
{
    public class OrderTotal
    {
        [JsonProperty("tableNo")] public string tableNo { get; set; }

        [JsonProperty("orderID")] public string id { get; set; }

        [JsonProperty("totalPrice")] public double totalPrice { get; set; }

        [JsonProperty("date")] public string date { get; set; }
    }
}