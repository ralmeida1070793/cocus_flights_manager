using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.DatabaseTests
{
    [TestClass]
    public class AirportTests
    {
        public Database.Context.DbContext Context { get; set; }
        
        public AirportTests()
        {
            /* Create a Memory Database instead of using the SQL */
            var optionsBuilder = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: "temp")
                .Options;

            Context = new Database.Context.DbContext(optionsBuilder);
        }

        [TestMethod]
        public void AddAirport()
        {
            Database.Context.Airport airport = new Database.Context.Airport()
            {
                Id = 1,
                Name = "Airport 1",
                Latitude = 123,
                Longitude = 321
            };

            var result = Context.Airports.Add(airport);
            Assert.IsTrue(result.State == EntityState.Added);
            
            Context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void UpdateAirport()
        {
            Database.Context.Airport airport = new Database.Context.Airport()
            {
                Id = 1,
                Name = "Airport 1",
                Latitude = 123,
                Longitude = 321
            };

            Context.Airports.Add(airport);
            airport.Name = "Airport 2";

            var result = Context.Airports.Update(airport);
            Assert.IsTrue(result.State == EntityState.Modified);

            Context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void DeleteAirport()
        {
            Database.Context.Airport airport = new Database.Context.Airport()
            {
                Id = 1,
                Name = "Airport 1",
                Latitude = 123,
                Longitude = 321
            };

            Context.Airports.Add(airport);
            var result = Context.Airports.Remove(airport);
            Assert.IsTrue(result.State == EntityState.Detached);

            Context.Database.EnsureDeleted();
        }
        
        [TestMethod]
        public void GetAirport()
        {
            Database.Context.Airport airport = new Database.Context.Airport()
            {
                Id = 1,
                Name = "Airport 1",
                Latitude = 123,
                Longitude = 321
            };

            Context.Airports.Add(airport);
            var result = Context.Airports.Find((long)1);
            Assert.IsTrue(airport.Equals(result));

            Context.Database.EnsureDeleted();
        }
    }
}
