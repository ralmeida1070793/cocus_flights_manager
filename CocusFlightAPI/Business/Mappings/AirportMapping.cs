using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappings
{
    public static class AirportMapping
    {
        public static Database.Context.Airport ToDatabase(
            this Entities.Models.Airport entity
        )
        {
            return new Database.Context.Airport()
            {
                Id = entity.Id.GetValueOrDefault(),
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                Name = entity.Name
            };
        }

        public static Entities.Models.Airport ToModel(
            this Database.Context.Airport entity
        )
        {
            return new Entities.Models.Airport()
            {
                Id = entity.Id,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                Name = entity.Name
            };
        }
    }
}
