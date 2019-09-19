using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels
{
    public class FlightConsumption
    {
        public Flight Flight { get; set; }
        public double DistanceNmi { get; set; }
        public Aeroplane Aeroplane { get; set; }
        public double Consumption { get; set; }
    }
}
