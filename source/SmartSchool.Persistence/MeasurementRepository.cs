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

        public IEnumerable<Measurement> GetMeasurementByLocationAndName(string location, string name) => _dbContext
                                                                                                        .Measurements
                                                                                                        .Include(s => s.Sensor)
                                                                                                        .Where(s => s.Sensor.Location == location)
                                                                                                        .Where(s => s.Sensor.Name == name);

        public IEnumerable<Measurement> GetCo2MeasurementsByLocationAndRange(string location, int min, int max) => _dbContext
                                                                                        .Measurements
                                                                                        .Include(s => s.Sensor)
                                                                                        .Where(s => s.Sensor.Location == location)
                                                                                        .Where(s => s.Sensor.Name == "co2")
                                                                                        .Where(s => s.Value > min)
                                                                                        .Where(s => s.Value < max);

    }
}