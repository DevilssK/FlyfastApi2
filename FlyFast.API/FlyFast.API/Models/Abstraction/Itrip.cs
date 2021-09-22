using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyFast.API.Models.Abstraction
{
    interface Itrip
    {
        int Id { get; set; }

        DateTime Date { get; set; }

        List<Line> Line { get; set; }
    }
}
