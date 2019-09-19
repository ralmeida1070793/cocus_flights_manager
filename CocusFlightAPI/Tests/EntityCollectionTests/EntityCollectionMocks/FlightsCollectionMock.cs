using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.EntityCollectionTests.EntityCollectionMocks
{
    public class FlightsCollectionMock
    {
        private readonly EntityCollection<Flight> _collection;
        private readonly AirportsCollectionMock _airportsCollection = new AirportsCollectionMock();
        public FlightsCollectionMock()
        {
            var airports = _airportsCollection.GetCollection().Entities;
            this._collection = new EntityCollection<Flight>()
            {
                Total = 20,
                Entities = new List<Flight>
                {
                    new Flight { Id = 1, Departure = airports.ElementAt(0), Destination = airports.ElementAt(1) },
                    new Flight { Id = 2, Departure = airports.ElementAt(1), Destination = airports.ElementAt(0) },
                    new Flight { Id = 3, Departure = airports.ElementAt(0), Destination = airports.ElementAt(2) },
                    new Flight { Id = 4, Departure = airports.ElementAt(2), Destination = airports.ElementAt(0) },
                    new Flight { Id = 5, Departure = airports.ElementAt(0), Destination = airports.ElementAt(3) },
                    new Flight { Id = 6, Departure = airports.ElementAt(3), Destination = airports.ElementAt(0) },
                    new Flight { Id = 7, Departure = airports.ElementAt(0), Destination = airports.ElementAt(4) },
                    new Flight { Id = 8, Departure = airports.ElementAt(4), Destination = airports.ElementAt(0) },
                    new Flight { Id = 9, Departure = airports.ElementAt(1), Destination = airports.ElementAt(2) },
                    new Flight { Id = 10, Departure = airports.ElementAt(2), Destination = airports.ElementAt(1) },
                    new Flight { Id = 11, Departure = airports.ElementAt(1), Destination = airports.ElementAt(3) },
                    new Flight { Id = 12, Departure = airports.ElementAt(3), Destination = airports.ElementAt(1) },
                    new Flight { Id = 13, Departure = airports.ElementAt(1), Destination = airports.ElementAt(4) },
                    new Flight { Id = 14, Departure = airports.ElementAt(4), Destination = airports.ElementAt(1) },
                    new Flight { Id = 15, Departure = airports.ElementAt(2), Destination = airports.ElementAt(3) },
                    new Flight { Id = 16, Departure = airports.ElementAt(3), Destination = airports.ElementAt(2) },
                    new Flight { Id = 17, Departure = airports.ElementAt(2), Destination = airports.ElementAt(4) },
                    new Flight { Id = 18, Departure = airports.ElementAt(4), Destination = airports.ElementAt(2) },
                    new Flight { Id = 19, Departure = airports.ElementAt(3), Destination = airports.ElementAt(4) },
                    new Flight { Id = 20, Departure = airports.ElementAt(4), Destination = airports.ElementAt(3) }
                }
            };
        }

        public EntityCollection<Flight> GetCollection()
        {
            return this._collection;
        }
    }
}
