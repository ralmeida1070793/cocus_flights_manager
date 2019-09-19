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
    public class AirportValidationTests
    {
        private readonly AirportsCollectionMock _mockAirportCollection = new AirportsCollectionMock();

        public AirportValidationTests()
        { }

        [TestMethod]
        public void ValidAirportTest()
        {
            Assert.IsTrue(_mockAirportCollection.GetCollection().Entities.ElementAt(0).IsValid());
        }
    }
}
