using Entities.Models;
using Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tests.EntityCollectionTests.EntityCollectionMocks;

namespace Tests.EntityCollectionTests
{
    [TestClass]
    public class AirportCollectionTests
    {
        private readonly AirportsCollectionMock _mockAirportCollection = new AirportsCollectionMock();
        
        public AirportCollectionTests()
        { }

        [TestMethod]
        public void GetListOfAirportsTest()
        {
            Assert.IsTrue(_mockAirportCollection.GetCollection().Total == 5);
        }

        [TestMethod]
        public void AddAirportTest()
        {
            var airport = new Airport { Id = 6, Latitude = 34.786374, Longitude = 135.437845, Name = "Osaka International Airport" };
            _mockAirportCollection.GetCollection().Entities.Add(airport);

            Assert.IsTrue(
                _mockAirportCollection.GetCollection().Entities.Contains(airport) && 
                _mockAirportCollection.GetCollection().Entities.Count == 6
            );
        }
        
    }
}
