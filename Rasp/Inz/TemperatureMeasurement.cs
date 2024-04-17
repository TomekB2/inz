using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Inz.Data;
using Iot.Device.OneWire;

namespace Inz
{
    public class TemperatureMeasurement
    {
        OneWireThermometerDevice device1;
        string username;

        public TemperatureMeasurement()
        {
            device1 = OneWireThermometerDevice.EnumerateDevices().First();
        }
        public void ReadTemperature()
        {
            StartFermentation();
            using (var context = new AppDbContext())
            {
                var temp = new Temperatures { inside_temperature = device1.ReadTemperature().Value, outside_temperature = device1.ReadTemperature().Value, measure_id = context.measures.Where(x => x.is_active == true).First().id, date = DateTime.UtcNow };
                Console.WriteLine($"Zapisano temperature fermentacji: {temp.inside_temperature}, temperature otoczenia: {temp.outside_temperature}, Data: {temp.date}");
                context.temperatures.Add(temp);
                context.SaveChanges();
            }
        }
        public bool CheckIfFermentationIsActive()
        {
            using (var context = new AppDbContext())
            {
                if (context.measures.Where(x => x.is_active == true).Count() == 0)
                {
                    return false;
                }
                else return true;
            }
        }
        public void StartFermentation()
        { 
            if (!CheckIfFermentationIsActive()) 
            {
                using (var context = new AppDbContext())
                { 
                    var newFermentation = new Measures { is_active = true, start_time = DateTime.UtcNow };
                    context.measures.Add(newFermentation);
                    context.SaveChanges();
                }
            }
        }
    }
}

