using Entities.Models;
using Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.EntityCollectionTests.EntityCollectionMocks;

namespace Tests.Business
{
    [TestClass]
    public class FlightTests
    {
        private readonly FlightsCollectionMock _mockFlightCollection = new FlightsCollectionMock();
        private readonly AeroplanesCollectionMock _mockAeroplanesCollection = new AeroplanesCollectionMock();

        public FlightTests()
        { }

        [TestMethod]
        public void GetConsumptionTest()
        {
            Aeroplane aeroplane = _mockAeroplanesCollection.GetCollection().Entities.First();
            Flight flight = _mockFlightCollection.GetCollection().Entities.First();

            var distance = flight.GetFlightDistance();
            var consumption = aeroplane.GetPlaneConsumption(distance);

            Assert.IsTrue(distance == 4115.29);
            Assert.IsTrue(consumption == 4098828.84);
        }
    }
}
