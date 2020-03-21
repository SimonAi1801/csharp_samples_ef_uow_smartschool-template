﻿using SmartSchool.Core.Entities;
using System.Collections.Generic;

namespace SmartSchool.Core.Contracts
{
    public interface IMeasurementRepository
    {
        void AddRange(Measurement[] measurements);
        Measurement[] GetAllMeasurements();
        Measurement[] GetMeasurementByLocationAndName(string location, string name);
        double GetCo2MeasurementsByLocationAndRange(string location, int min, int max);
        int GetMeasurementCountByLocationAndName(string location, string name);
    }
}
