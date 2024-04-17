using Inz;
using Inz.Data;
using Inz.HealthCheck;
using Iot.Device.OneWire;
using Microsoft.AspNetCore.Identity;
using System.Timers;

namespace MyApp
{
    public class Program
    {
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            TemperatureMeasurement tm = new TemperatureMeasurement();
            tm.ReadTemperature();
        }
        public static void Main(string[] args)
        {
            var timer = Convert.ToInt32(Inz.Settings.GetPeriod());        
            HealthCheck healthCheck = new HealthCheck(args);
            healthCheck.Run();
            TemperatureMeasurement tm = new TemperatureMeasurement();
            tm.ReadTemperature();
            var aTimer = new System.Timers.Timer(timer * 60 * 1000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Start();
            Console.ReadLine();
        }
    }
}
