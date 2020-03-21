using SmartSchool.Core.Entities;
using System.Collections.Generic;

namespace SmartSchool.Core.Contracts
{
    public interface IMeasurementRepository
    {
        void AddRange(Measurement[] measurements);

        Measurement[] GetAllMeasurements();

        IEnumerable<Measurement> GetMeasurementBySensorLocationAndName(string location, string name);
    }
}
