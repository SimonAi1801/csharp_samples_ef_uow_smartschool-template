using SmartSchool.Core.Contracts;
using System.Linq;
using System.Collections.Generic;
using SmartSchool.Core.Entities;

namespace SmartSchool.Persistence
{
    public class SensorRepository : ISensorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SensorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Sensor[] GetAllSensors() => _dbContext.Sensors.ToArray();



    }
}