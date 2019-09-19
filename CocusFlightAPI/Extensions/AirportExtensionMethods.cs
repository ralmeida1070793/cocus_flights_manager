using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions
{
    public static class AirportExtensionMethods
    {
        public static KeyValuePair<double, double> GetCoordinates(this Airport airport)
        {
            return new KeyValuePair<double, double>(airport.Latitude, airport.Longitude);
        }
    }
}
