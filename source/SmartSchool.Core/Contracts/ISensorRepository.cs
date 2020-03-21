using SmartSchool.Core.Entities;
namespace SmartSchool.Core.Contracts
{
    public interface ISensorRepository
    {
        Sensor[] GetAllSensors();
        void Add(Sensor sensor);
        void Update(Sensor sensor);
    }
}
