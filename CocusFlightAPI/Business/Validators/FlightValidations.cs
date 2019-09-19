using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators
{
    public static class FlightValidations
    {
        private static bool DepartureIsNotNull(this Flight entity)
        {
            return entity.Departure != null;
        }

        private static bool DestinationIsNotNull(this Flight entity)
        {
            return entity.Destination != null;
        }

        private static bool IsGoingSomewhere(this Flight entity)
        {
            return entity.Departure != entity.Destination && 
                entity.Departure.Latitude != entity.Destination.Latitude && 
                entity.Departure.Longitude != entity.Destination.Longitude;
        }
        
        public static bool IsValid(this Flight entity)
        {
            return entity.DestinationIsNotNull() &&
                entity.DepartureIsNotNull() &&
                entity.IsGoingSomewhere();
        }
    }
}
