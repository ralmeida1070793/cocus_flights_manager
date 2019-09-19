using Entities.Models;
using Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tests.EntityCollectionTests.EntityCollectionMocks;

namespace Tests.EntityCollectionTests
{
    [TestClass]
    public class FlightCollectionTests
    {
        private readonly FlightsCollectionMock _mockFlightCollection = new FlightsCollectionMock();
        
        public FlightCollectionTests()
        { }

        [TestMethod]
        public void GetListOfFlightsTest()
        {
            Assert.IsTrue(_mockFlightCollection.GetCollection().Total == 20);
        }

        [TestMethod]
        public void AddFlightTest()
        {
            var flight = new Flight { Id = 21, Departure = new Airport { Id = 6, Latitude = 100, Longitude = 200, Name = "Origin Test Airport" }, Destination = new Airport { Id = 7, Latitude = 101, Longitude = 201, Name = "Destination Test Airport" } };
            _mockFlightCollection.GetCollection().Entities.Add(flight);

            Assert.IsTrue(
                _mockFlightCollection.GetCollection().Entities.Contains(flight) &&
                _mockFlightCollection.GetCollection().Entities.Count == 21
            );
        }
    }
}
