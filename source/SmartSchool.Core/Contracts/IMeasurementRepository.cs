using SmartSchool.Core.Entities;
using System.Collections.Generic;

namespace SmartSchool.Core.Contracts
{
    public interface IMeasurementRepository
    {
        void AddRange(Measurement[] measurements);

        Measurement[] GetAllMeasurements();

        IEnumerable<Measurement> GetMeasurementByLocationAndName(string location, string name);
        IEnumerable<Measurement> GetCo2MeasurementsByLocationAndRange(string location, int min, int max);
    }
}
