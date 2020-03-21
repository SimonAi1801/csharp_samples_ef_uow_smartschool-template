using SmartSchool.Core.Entities;
using System.Collections.Generic;

namespace SmartSchool.Core.Contracts
{
    public interface IMeasurementRepository
    {
        void AddRange(Measurement[] measurements);
        Measurement[] GetMeasurementByLocationAndName(string location, string name);
        double GetCo2MeasurementsAvgByLocationAndRange(string location, int min, int max);
        int GetMeasurementCountByLocationAndName(string location, string name);


    }

}
