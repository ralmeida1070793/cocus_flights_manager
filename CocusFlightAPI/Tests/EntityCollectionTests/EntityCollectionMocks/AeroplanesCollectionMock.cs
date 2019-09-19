using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.EntityCollectionTests.EntityCollectionMocks
{
    public class AeroplanesCollectionMock
    {
        private readonly EntityCollection<Aeroplane> _collection;
        public AeroplanesCollectionMock()
        {
            this._collection = new EntityCollection<Aeroplane>()
            {
                Total = 5,
                Entities = new List<Aeroplane>
                {
                    new Aeroplane { Id = 1, Name = "Airbus A330", Capacity = 300, TakeoffEffortPerOccupiedSeat = 6.4, FuelConsumptionPerSeat = 3.32 },
                    new Aeroplane { Id = 2, Name = "Airbus A350", Capacity = 315, TakeoffEffortPerOccupiedSeat = 6.03, FuelConsumptionPerSeat = 2.39 },
                    new Aeroplane { Id = 3, Name = "Airbus A380", Capacity = 525, TakeoffEffortPerOccupiedSeat = 13.78, FuelConsumptionPerSeat = 3.27 },
                    new Aeroplane { Id = 4, Name = "Boeing 747", Capacity = 416, TakeoffEffortPerOccupiedSeat = 11.11, FuelConsumptionPerSeat = 3.34 },
                    new Aeroplane { Id = 5, Name = "Boeing 777", Capacity = 301, TakeoffEffortPerOccupiedSeat = 7.42, FuelConsumptionPerSeat = 3.08 }
                }
            };
        }

        public EntityCollection<Aeroplane> GetCollection()
        {
            return this._collection;
        }
    }
}
