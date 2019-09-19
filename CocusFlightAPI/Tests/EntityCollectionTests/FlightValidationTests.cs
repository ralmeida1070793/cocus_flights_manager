using Business.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.EntityCollectionTests.EntityCollectionMocks;

namespace Tests.EntityCollectionTests
{
    [TestClass]
    public class FlightValidationTests
    {
        private readonly FlightsCollectionMock _mockFlightCollection = new FlightsCollectionMock();

        public FlightValidationTests()
        { }

        [TestMethod]
        public void ValidAirportTest()
        {
            Assert.IsTrue(_mockFlightCollection.GetCollection().Entities.ElementAt(0).IsValid());
        }
    }
}
