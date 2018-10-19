using Microsoft.VisualStudio.TestTools.UnitTesting;
using NordCloudAssignment.Domain;
using System;

namespace NordCloudAssignmentTest.Domain.LinkStationTest
{
    [TestClass]
    public class ConstructorTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Link_station_constructor_should_throw_argument_exception_if_no_position_supplied()
        {
            var linkStation = new LinkStation(null, 0);
        }

        [TestMethod]
        public void Link_station_constructor_should_create_a_new_link_station_if_position_supplied()
        {
            var linkStation = new LinkStation(new Position(0, 0), 0);

            Assert.IsNotNull(linkStation);
        }
    }
}
