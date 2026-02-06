using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsDataServer.DataAccess
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly StatisticDbContext _context = new();

        public List<StatisticType> GetAllTypes()
        {
            return _context.StatisticTypes.ToList();
        }

        public List<StatisticRecord> GetRecordsByType(int typeId)
        {
            return _context.StatisticRecords
                           .Where(r => r.TypeId == typeId)
                           .ToList();
        }
    }
}