namespace Backend
{
    public class TemperatureList
    {
        public int id { get; set; }

        public DateTime date { get; set; }

        public double outsideTemperature { get; set; }
        public double insideTemperature { get; set; }
    }
}
