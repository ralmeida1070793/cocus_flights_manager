using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    /// <summary>
    /// Aeroplane Entity
    /// </summary>
    public class Aeroplane
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public long Capacity { get; set; }
        public double TakeoffEffortPerOccupiedSeat { get; set; }
        public double MilesToCruisingAltitude { get; set; }
        public double FuelConsumptionPerSeat { get; set; }
    }
}
