using Entities.Models;
using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions
{
    public static class FlightExtensionMethods
    {
        public static double GetFlightDistance(this Flight flight)
        {
            return Math.Round(Calculate(flight.Departure.GetCoordinates(), flight.Destination.GetCoordinates()), 2);
        }

        private static double Calculate(KeyValuePair<double,double> departure, KeyValuePair<double, double> destination)
        {
            var departureCoordinates = new GeoCoordinate(departure.Key, departure.Value);
            var destinationCoordinates = new GeoCoordinate(destination.Key, destination.Value);

            return departureCoordinates.GetDistanceTo(destinationCoordinates);
        }
    }
}
