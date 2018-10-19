using Microsoft.VisualStudio.TestTools.UnitTesting;
using NordCloudAssignment.Domain;
using System;

namespace NordCloudAssignmentTest.Domain.LinkStationTest
{
    [TestClass]
    public class PowerAtPositionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Power_at_position_should_throw_argument_exception_if_no_position_supplied()
        {
            var linkStation = new LinkStation(new Position(0, 0), 1);

            linkStation.PowerAtPosition(null);
        }

        [TestMethod]
        public void Power_at_position_should_return_the_square_of_the_reach_if_the_position_is_at_the_station()
        {
            var linkStation = new LinkStation(new Position(2, 2), 2);

            var powerAtPosition = linkStation.PowerAtPosition(new Position(2, 2));

            Assert.AreEqual(4, powerAtPosition);
        }

        [TestMethod]
        public void Power_at_position_should_adjust_the_available_power_if_the_position_is_not_at_the_station()
        {
            var linkStation = new LinkStation(new Position(0, 0), 2);

            var powerAtPosition = linkStation.PowerAtPosition(new Position(0, 1));

            Assert.AreEqual(1, powerAtPosition);
        }

        [TestMethod]
        public void Power_at_position_should_identify_when_a_station_is_too_far_away_from_a_position_to_supply_power()
        {
            var linkStation = new LinkStation(new Position(0, 0), 2);

            var powerAtPosition = linkStation.PowerAtPosition(new Position(0, 3));

            Assert.AreEqual(0, powerAtPosition);
        }
    }
}
