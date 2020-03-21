using SmartSchool.Core.Entities;
using System.Collections.Generic;
namespace SmartSchool.Core.Contracts
{
    public interface ISensorRepository
    {
        (string Name, string Location, double Avg)[] GetAllAvgSensors();
    }
}
