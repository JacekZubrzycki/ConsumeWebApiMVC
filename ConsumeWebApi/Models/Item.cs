using Newtonsoft.Json;

namespace ConsumeWebApi.Models
{
    public class Item

    {
        public Item()
        {
        }

        public Item(string id, string name, string desc, string price, string type)
        {
            Id = id;
            this.name = name;
            this.desc = desc;
            this.price = price;
            this.type = type;
        }

        [JsonProperty("itemId")] public string Id { get; set; }

        [JsonProperty("itemName")] public string name { get; set; }

        [JsonProperty("itemDesc")] public string desc { get; set; }

        [JsonProperty("itemPrice")] public string price { get; set; }

        [JsonProperty("itemType")] public string type { get; set; }
    }
}
