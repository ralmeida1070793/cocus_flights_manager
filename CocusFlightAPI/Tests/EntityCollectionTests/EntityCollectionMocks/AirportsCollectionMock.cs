using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.EntityCollectionTests.EntityCollectionMocks
{
    public class AirportsCollectionMock
    {
        private readonly EntityCollection<Airport> _collection;
        public AirportsCollectionMock()
        {
            this._collection = new EntityCollection<Airport>()
            {
                Total = 5,
                Entities = new List<Airport>
                {
                    new Airport { Id = 1, Latitude = 41.242240, Longitude = -8.678573, Name = "Aeroporto Francisco Sá Carneiro" },
                    new Airport { Id = 2, Latitude = 37.017605, Longitude = -7.969795, Name = "Aeroporto de Faro" },
                    new Airport { Id = 3, Latitude = 38.775888, Longitude = -9.135671, Name = "Aeroporto da Portela" },
                    new Airport { Id = 4, Latitude = 51.470082, Longitude = -0.454253, Name = "Heathrow Airport" },
                    new Airport { Id = 5, Latitude = 51.470082, Longitude = -0.454253, Name = "Frankfurt International Airport" }
                }
            };
        }

        public EntityCollection<Airport> GetCollection()
        {
            return this._collection;
        }
    }
}
