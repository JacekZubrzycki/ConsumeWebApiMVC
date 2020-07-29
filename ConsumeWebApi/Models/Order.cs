using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ConsumeWebApi.Models
{
    public class Order
    {
        [Display(Name = "Item Name"), JsonProperty("itemName")] public string itemName { get; set; }

        [JsonProperty("itemID")] public int itemID { get; set; }

        [Display(Name = "Table Number"), JsonProperty("tableNo")] public int tableNO { get; set; }
        [Display(Name = "Quantity"), JsonProperty("quantity")] public int quantity { get; set; }
    }
}