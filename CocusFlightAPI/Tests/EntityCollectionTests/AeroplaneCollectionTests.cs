using Entities.Models;
using Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tests.EntityCollectionTests.EntityCollectionMocks;

namespace Tests.EntityCollectionTests
{
    [TestClass]
    public class AeroplaneCollectionTests
    {
        private AeroplanesCollectionMock _mockAeroplaneCollection = new AeroplanesCollectionMock();
        
        public AeroplaneCollectionTests()
        { }

        [TestMethod]
        public void GetListOfFlightsTest()
        {
            Assert.IsTrue(_mockAeroplaneCollection.GetCollection().Total == 5);
        }

        [TestMethod]
        public void AddAeroplaneTest()
        {
            var aeroplane = new Aeroplane { Id = 6, Name = "Boeing 787", Capacity = 243, TakeoffEffortPerOccupiedSeat = 5.38, FuelConsumptionPerSeat = 2.77 };
            _mockAeroplaneCollection.GetCollection().Entities.Add(aeroplane);

            Assert.IsTrue(
                _mockAeroplaneCollection.GetCollection().Entities.Contains(aeroplane) &&
                _mockAeroplaneCollection.GetCollection().Entities.Count == 6
            );
        }
    }
}
