using Business.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tests.EntityCollectionTests.EntityCollectionMocks;

namespace Tests.EntityCollectionTests
{
    [TestClass]
    public class AeroplaneValidationTests
    {
        private AeroplanesCollectionMock _mockAeroplaneCollection = new AeroplanesCollectionMock();

        public AeroplaneValidationTests()
        { }

        [TestMethod]
        public void ValidAirportTest()
        {
            Assert.IsTrue(_mockAeroplaneCollection.GetCollection().Entities.ElementAt(0).IsValid());
        }
    }
}
