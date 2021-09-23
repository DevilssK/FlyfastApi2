using FlyFast.API.Models.ExternalModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models
{
    public class ExPlane
    {
        public string name { get; set; }

        [JsonProperty("total_seats")]
        public int total_seat { get; set; }
        public List<ExOptions> Options { get; internal set; }
    }
}