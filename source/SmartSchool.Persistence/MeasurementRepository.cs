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

        public void AddRange(Measurement[] measurements)
        {
            _dbContext.Measurements.AddRange(measurements);
        }

        public Measurement[] GetAllMeasurements() => _dbContext
                                                     .Measurements
                                                     .ToArray();

        public Measurement[] GetMeasurementByLocationAndName(string location, string name)
        {
            return _dbContext
                    .Measurements
                    .Include(s => s.Sensor)
                    .Where(s => s.Sensor.Location.Equals(location) && s.Sensor.Name.Equals(name))
                    .OrderByDescending(m => m.Value)
                    .ThenByDescending(m => m.Time)
                    .Take(3)
                    .ToArray();
        }
        public int GetMeasurementCountByLocationAndName(string location, string name)
        {
            return _dbContext
                   .Measurements
                   .Include(m => m.Sensor)
                   .Where(m => m.Sensor.Location.Equals(location) && m.Sensor.Name.Equals(name))
                   .Count();
                   
        }

        public double GetCo2MeasurementsByLocationAndRange(string location, int min, int max)
        {
            return _dbContext
                    .Measurements
                    .Include(s => s.Sensor)
                    .Where(s => s.Sensor.Location.Equals(location) && s.Sensor.Name.Equals("co2"))
                    .Where(s => s.Value > min && s.Value < max)
                    .Average(s => s.Value);
        }
    }
}