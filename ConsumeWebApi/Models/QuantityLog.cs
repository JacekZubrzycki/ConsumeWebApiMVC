using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ConsumeWebApi.Models
{
    public class QuantityLog
    {
        [JsonProperty("itemID")] public int itemID { get; set; }
        [Display(Name = "Item Name"), JsonProperty("itemName")] public string itemName { get; set; }
        [Display(Name = "Quantity"), JsonProperty("quantitybought")] public int quantityBought { get; set; }
    }
}