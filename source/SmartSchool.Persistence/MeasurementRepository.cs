using SmartSchool.Core.Contracts;
using SmartSchool.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.Persistence
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private ApplicationDbContext _dbContext;

        public MeasurementRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  void AddRange(Measurement[] measurements)
        {
            _dbContext.Measurements.AddRange(measurements);
        }

        public Measurement[] GetAllMeasurements() => _dbContext
                                                     .Measurements
                                                     .ToArray();

        public IEnumerable<Measurement> GetMeasurementBySensorLocationAndName(string location, string name) => _dbContext
                                                                                                               .Measurements
                                                                                                               .Include(s => s.Sensor)
                                                                                                               .Where(m => m.Sensor.Location == location)
                                                                                                               .Where(m => m.Sensor.Name == name);

    }
}