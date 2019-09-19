using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappings
{
    public static class AeroplaneMapping
    {
        public static Database.Context.Aeroplane ToDatabase(
            this Entities.Models.Aeroplane entity
        )
        {
            return new Database.Context.Aeroplane()
            {
                Id = entity.Id.GetValueOrDefault(),
                Capacity = entity.Capacity,
                FuelConsumptionPerSeat = entity.FuelConsumptionPerSeat,
                TakeoffEffortPerOccupiedSeat = entity.TakeoffEffortPerOccupiedSeat,
                Name = entity.Name
            };
        }

        public static Entities.Models.Aeroplane ToModel(
            this Database.Context.Aeroplane entity
        )
        {
            return new Entities.Models.Aeroplane()
            {
                Id = entity.Id,
                Capacity = entity.Capacity,
                TakeoffEffortPerOccupiedSeat = entity.TakeoffEffortPerOccupiedSeat,
                FuelConsumptionPerSeat = entity.FuelConsumptionPerSeat,
                Name = entity.Name
            };
        }
    }
}
