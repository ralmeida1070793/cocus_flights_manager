using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.DatabaseTests
{
    [TestClass]
    public class AeroplaneTests
    {
        public Database.Context.DbContext Context { get; set; }
        
        public AeroplaneTests()
        {
            /* Create a Memory Database instead of using the SQL */
            var optionsBuilder = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: "temp")
                .Options;

            Context = new Database.Context.DbContext(optionsBuilder);
        }

        [TestMethod]
        public void AddAeroplane()
        {
            Database.Context.Aeroplane aeroplane = new Database.Context.Aeroplane()
            {
                Id = 1,
                Name = "cessna 172",
                Capacity = 4,
                FuelConsumptionPerSeat = 10,
                MilesToCruisingAltitude = 12,
                TakeoffEffortPerOccupiedSeat = 15
            };

            var result = Context.Aeroplanes.Add(aeroplane);
            Assert.IsTrue(result.State == EntityState.Added);
            
            Context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void UpdateAeroplane()
        {
            Database.Context.Aeroplane aeroplane = new Database.Context.Aeroplane()
            {
                Id = 1,
                Name = "cessna 172",
                Capacity = 4,
                FuelConsumptionPerSeat = 10,
                MilesToCruisingAltitude = 12,
                TakeoffEffortPerOccupiedSeat = 15
            };

            Context.Aeroplanes.Add(aeroplane);
            aeroplane.Name = "cessna 182";

            var result = Context.Aeroplanes.Update(aeroplane);
            Assert.IsTrue(result.State == EntityState.Modified);

            Context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void DeleteAeroplane()
        {
            Database.Context.Aeroplane aeroplane = new Database.Context.Aeroplane()
            {
                Id = 1,
                Name = "cessna 172",
                Capacity = 4,
                FuelConsumptionPerSeat = 10,
                MilesToCruisingAltitude = 12,
                TakeoffEffortPerOccupiedSeat = 15
            };

            Context.Aeroplanes.Add(aeroplane);
            var result = Context.Aeroplanes.Remove(aeroplane);
            Assert.IsTrue(result.State == EntityState.Detached);

            Context.Database.EnsureDeleted();
        }
        
        [TestMethod]
        public void GetAeroplane()
        {
            Database.Context.Aeroplane aeroplane = new Database.Context.Aeroplane()
            {
                Id = 1,
                Name = "cessna 172",
                Capacity = 4,
                FuelConsumptionPerSeat = 10,
                MilesToCruisingAltitude = 12,
                TakeoffEffortPerOccupiedSeat = 15
            };

            Context.Aeroplanes.Add(aeroplane);
            var result = Context.Aeroplanes.Find((long)1);
            Assert.IsTrue(aeroplane.Equals(result));

            Context.Database.EnsureDeleted();
        }
    }
}
