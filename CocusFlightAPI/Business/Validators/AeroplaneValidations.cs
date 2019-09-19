using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators
{
    public static class AeroplaneValidations
    {
        private static bool NameIsNotNull(this Aeroplane entity)
        {
            return !String.IsNullOrEmpty(entity.Name);
        }

        private static bool CapacityIsValid(this Aeroplane entity)
        {
            return entity.Capacity > 0;
        }

        private static bool CunsumpltionIsValid(this Aeroplane entity)
        {
            return entity.FuelConsumptionPerSeat > 0 && entity.TakeoffEffortPerOccupiedSeat > 0;
        }
        
        public static bool IsValid(this Aeroplane entity)
        {
            return entity.NameIsNotNull() &&
                entity.CapacityIsValid() &&
                entity.CunsumpltionIsValid();
        }
    }
}
