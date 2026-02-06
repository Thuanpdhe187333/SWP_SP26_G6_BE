using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StatsDataServer.DataAccess;

namespace StatsDataServer.Business
{
    public class StatisticManager
    {
        private readonly StatisticRepository _repo = new();

        public object LoadTypes()
        {
            return _repo.GetAllTypes();
        }

        public object LoadRecords(int typeId)
        {
            return _repo.GetRecordsByType(typeId);
        }
    }
}
