using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.DatabaseTests
{
    [TestClass]
    public class FlightTests
    {
        public Database.Context.DbContext Context { get; set; }
        
        public FlightTests()
        {
            /* Create a Memory Database instead of using the SQL */
            var optionsBuilder = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: "temp")
                .Options;

            Context = new Database.Context.DbContext(optionsBuilder);
        }

        [TestMethod]
        public void AddFlight()
        {
            Database.Context.Flight flight = new Database.Context.Flight()
            {
                Id = 1,
                DestinationId = 1,
                OriginId = 1
            };

            var result = Context.Flights.Add(flight);
            Assert.IsTrue(result.State == EntityState.Added);
            
            Context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void UpdateFlight()
        {
            Database.Context.Flight flight = new Database.Context.Flight()
            {
                Id = 1,
                DestinationId = 1,
                OriginId = 1
            };

            Context.Flights.Add(flight);
            flight.DestinationId = 2;

            var result = Context.Flights.Update(flight);
            Assert.IsTrue(result.State == EntityState.Modified);

            Context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void DeleteFlight()
        {
            Database.Context.Flight flight = new Database.Context.Flight()
            {
                Id = 1,
                DestinationId = 1,
                OriginId = 1
            };

            Context.Flights.Add(flight);
            var result = Context.Flights.Remove(flight);
            Assert.IsTrue(result.State == EntityState.Detached);

            Context.Database.EnsureDeleted();
        }
        
        [TestMethod]
        public void GetFlight()
        {
            Database.Context.Flight flight = new Database.Context.Flight()
            {
                Id = 1,
                DestinationId = 1,
                OriginId = 1
            };

            Context.Flights.Add(flight);
            var result = Context.Flights.Find((long)1);
            Assert.IsTrue(flight.Equals(result));

            Context.Database.EnsureDeleted();
        }
    }
}
