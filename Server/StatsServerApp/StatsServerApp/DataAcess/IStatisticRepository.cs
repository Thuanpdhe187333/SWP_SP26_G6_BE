using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsDataServer.DataAccess
{
    public interface IStatisticRepository
    {
        List<StatisticType> GetAllTypes();
        List<StatisticRecord> GetRecordsByType(int typeId);
    }
}