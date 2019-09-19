using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions
{
    public static class AeroplaneExtentionMethods
    {
        public static double GetPlaneConsumption(this Aeroplane aeroplane, double distance)
        {
            return Math.Round(aeroplane.Capacity * aeroplane.FuelConsumptionPerSeat * (distance - aeroplane.MilesToCruisingAltitude) +
                aeroplane.Capacity * aeroplane.TakeoffEffortPerOccupiedSeat * aeroplane.MilesToCruisingAltitude, 2);
        }
    }
}
