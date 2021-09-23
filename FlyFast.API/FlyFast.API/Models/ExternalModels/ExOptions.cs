using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models.ExternalModels
{
    public class ExOptions
    {
        [JsonProperty("option_type")]
        public string optionsType;

        [JsonProperty("price")]
        public float price;
    }
}
