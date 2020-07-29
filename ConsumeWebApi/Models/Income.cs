using System.Collections;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ConsumeWebApi.Models
{
    public class Income
    {
        [Display(Name = "Income Today"),JsonProperty("daily")] public double daily { set; get; }
        [Display(Name = "Income this Month"),JsonProperty("monthly")] public double monthly { set; get; }
   
    }
}