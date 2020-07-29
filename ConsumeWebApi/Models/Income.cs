using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ConsumeWebApi.Models
{
    public class Income
    {
        [Display(Name = "Income for Today"),JsonProperty("daily")] public double daily { set; get; }
        [Display(Name = "Income for This Month"),JsonProperty("monthly")] public double monthly { set; get; }
    }
}