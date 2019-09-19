using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators
{
    public static class AirportValidations
    {
        private static bool NameIsNotNull(this Airport entity)
        {
            return !String.IsNullOrEmpty(entity.Name);
        }

        private static bool CoordinatesAreValid(this Airport entity)
        {
            return entity.Latitude != 0 && entity.Longitude != 0;
        }
        
        public static bool IsValid(this Airport entity)
        {
            return entity.NameIsNotNull() &&
                entity.CoordinatesAreValid();
        }
    }
}
