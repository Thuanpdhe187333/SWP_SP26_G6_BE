using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsDataServer.Dtos
{
    public class ClientMessage
    {
        public string Category { get; set; } = "";
        public string Action { get; set; } = "";
    }
}