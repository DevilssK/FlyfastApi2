using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace FlyFast.API.Models
{
    [XmlRoot("Cube")]
    public class Devise
    {
        [XmlAttribute("currency")]
        public string Currency { get; set; }

        [XmlAttribute("rate")]
        public float Rate { get; set; }

        public DateTime CurrentDate { get; set; }
    }
}