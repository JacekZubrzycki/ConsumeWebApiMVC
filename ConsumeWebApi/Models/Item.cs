using Newtonsoft.Json;

namespace ConsumeWebApi.Models
{
    public class Item

    {
        public Item(string Id, string ItemName, string Description, string Price, string Type)
        {
            this.Id = Id;
            this.ItemName = ItemName;
            this.Description = Description;
            this.Price = Price;
            this.Type = Type;
        }
        
        [JsonProperty("itemId")] public string Id { get; set; }

        [JsonProperty("itemName")] public string ItemName { get; set; }

        [JsonProperty("itemDesc")] public string Description { get; set; }

        [JsonProperty("itemPrice")] public string Price { get; set; }

        [JsonProperty("itemType")] public string Type { get; set; }
    }
}
