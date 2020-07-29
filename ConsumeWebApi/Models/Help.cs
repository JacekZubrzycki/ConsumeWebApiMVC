using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ConsumeWebApi.Models
{
    public class Help
    {
        [Display(Name = "Table Number"),JsonProperty("tableNo")] public string tableNo { set; get; }
        [JsonProperty("needHelp")] public bool needHelp { set; get; }
        
    }
}