using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsDataServer.DataAccess
{
    public class StatisticRecord
    {
        public int RecordId { get; set; }
        public int TypeId { get; set; }
        public DateTime RecordDate { get; set; }
        public double Value { get; set; }
    }
}
