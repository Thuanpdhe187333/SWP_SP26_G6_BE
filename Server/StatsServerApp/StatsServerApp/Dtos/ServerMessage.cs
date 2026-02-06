using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsDataServer.Dtos
{
    public class ServerMessage
    {
        public bool Success { get; set; }
        public object? Payload { get; set; }
        public string? Error { get; set; }
    }
}