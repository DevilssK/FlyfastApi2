using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace FlyFastApiProvider.Models.ViewModels
{
    [XmlRoot("gesmes:Envelope")]
    public class EnveloppeDeviseViewModel
    {
        [XmlElement("Cube")]
        public List<Devise> Devises { get; set; }
    }
}