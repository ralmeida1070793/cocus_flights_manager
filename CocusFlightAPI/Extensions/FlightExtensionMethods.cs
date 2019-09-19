using Entities.Models;
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
            double interval = destination.Value - departure.Value;
            double distance = Math.Sin(Degree2radians(destination.Key)) * Math.Sin(departure.Key) + Math.Cos(Degree2radians(destination.Key)) * Math.Cos(Degree2radians(departure.Key)) * Math.Cos(Degree2radians(interval));
            distance = Math.Acos(distance);
            distance = Radians2degree(distance);

            //For Nautical Miles
            return distance * 60 * 1.1515 * 0.8684;
        }

        private static double Degree2radians(double degree)
        {
            return (degree * Math.PI / 180.0);
        }

        private static double Radians2degree(double radians)
        {
            return (radians / Math.PI * 180.0);
        }
    }
}
