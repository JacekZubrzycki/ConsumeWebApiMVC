using Newtonsoft.Json;

namespace ConsumeWebApi.Models
{
    public class Order
    {
        [JsonProperty("itemName")] public string itemName { get; set; }
        [JsonProperty("itemID")] public int itemID { get; set; }

        [JsonProperty("tableNo")] public int tableNO { get; set; }

        [JsonProperty("quantity")] public int quantity { get; set; }
    }
}