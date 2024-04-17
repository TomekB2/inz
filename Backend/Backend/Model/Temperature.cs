using System;
using System.Collections.Generic;

namespace Backend.Model;

public partial class Temperature
{
    public int Id { get; set; }

    public double OutsideTemperature { get; set; }

    public double InsideTemperature { get; set; }

    public int MeasureId { get; set; }

    public DateTime Date { get; set; }
}
