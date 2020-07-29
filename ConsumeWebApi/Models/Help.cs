using Newtonsoft.Json;

namespace ConsumeWebApi.Models
{
    public class Help
    {
        [JsonProperty("tableNo")] public string tableNo { set; get; }
        [JsonProperty("needHelp")] public bool needHelp { set; get; }
        
    }
}