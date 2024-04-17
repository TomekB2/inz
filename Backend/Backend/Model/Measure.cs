using System;
using System.Collections.Generic;

namespace Backend.Model;

public partial class Measure
{
    public int Id { get; set; }

    public bool IsActive { get; set; }

    public DateTime? EndTime { get; set; }

    public DateTime StartTime { get; set; }
}
