using Newtonsoft.Json;

namespace ConsumeWebApi.Models
{
    public class Item

    {
        [JsonProperty("itemId")] public string Id { get; set; }

        [JsonProperty("itemName")] public string ItemName { get; set; }

        [JsonProperty("itemDesc")] public string Description { get; set; }

        [JsonProperty("itemPrice")] public string Price { get; set; }

        [JsonProperty("itemType")] public string Type { get; set; }
    }
}