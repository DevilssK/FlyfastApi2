using FlyFast.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFastApiProvider.Models.ViewModels
{
    public class UserLineViewModel
    {
        public int LineId { get; set; }
        public TICKET_TYPE TicketType { get; set; }
        public List<Option> Options { get; set; }

    }
}