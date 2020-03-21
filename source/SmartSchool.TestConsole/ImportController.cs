using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SmartSchool.Core.Entities;
using Utils;
using System.Linq;

namespace SmartSchool.TestConsole
{
    public class ImportController
    {
        const string Filename = "measurements.csv";

        /// <summary>
        /// Liefert die Messwerte mit den dazugehörigen Sensoren
        /// </summary>
        public static IEnumerable<Measurement> ReadFromCsv()
        {
            string filePath = MyFile.GetFullNameInApplicationTree(Filename);
            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            IDictionary<string, Sensor> sensors = new Dictionary<string, Sensor>();
            IList<Measurement> measurements = new List<Measurement>();
            bool isFirstRow = true;

            foreach (var item in lines)
            {
                if (!isFirstRow)
                {
                    string[] parts = item.Split(";");
                    string[] nameAndLocation = parts[2].Split("_");
                    DateTime dateTime = DateTime.Parse($"{parts[0]} {parts[1]}");
                    Measurement measurement = new Measurement() { Time = dateTime, Value = Convert.ToDouble(parts[3]) };
                    if (!sensors.ContainsKey(nameAndLocation[1]))
                    {
                        Sensor sensor = new Sensor() { Name = nameAndLocation[1], Location = nameAndLocation[0] };
                        measurement.Sensor = sensor;
                        sensor.Measurements.Add(measurement);
                        sensors.Add(nameAndLocation[1], sensor);
                    }
                    else
                    {
                        Sensor containedSensor = sensors.Values.SingleOrDefault(s => s.Name == nameAndLocation[1]);
                        measurement.Sensor = containedSensor;
                        containedSensor.Measurements.Add(measurement);

                    }
                    measurements.Add(measurement);
                }
                isFirstRow = false;
            }
            return measurements;
        }
    }
}
