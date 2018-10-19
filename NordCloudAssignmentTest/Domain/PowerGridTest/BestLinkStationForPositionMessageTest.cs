using Microsoft.VisualStudio.TestTools.UnitTesting;
using NordCloudAssignment.Domain;
using System;
using System.Collections.Generic;

namespace NordCloudAssignmentTest.Domain.PowerGridTest
{
    [TestClass]
    public class BestLinkStationForPositionMessageTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Best_link_station_for_position_message_should_throw_argument_exception_if_no_position_is_supplied()
        {
            var gridConfiguration = new List<List<double>>();
            gridConfiguration.Add(new List<double>() { 0, 0, 1 });
            var powerGrid = new PowerGrid(gridConfiguration);

            powerGrid.BestLinkStationForPositionMessage(null);
        }

        [TestMethod]
        public void Best_link_station_for_position_message_should_identify_the_best_station()
        {
            var gridConfiguration = new List<List<double>>();
            gridConfiguration.Add(new List<double>() { 0, 0, 1 });
            gridConfiguration.Add(new List<double>() { 2, 2, 2 });
            var powerGrid = new PowerGrid(gridConfiguration);

            var message = powerGrid.BestLinkStationForPositionMessage(new Position(2, 3));

            Assert.AreEqual("Best link station for point 2, 3 is 2, 2 with power 1", message);
        }

        [TestMethod]
        public void Best_link_station_for_position_message_should_identify_if_there_is_no_station_within_range()
        {
            var gridConfiguration = new List<List<double>>();
            gridConfiguration.Add(new List<double>() { 0, 0, 1 });
            gridConfiguration.Add(new List<double>() { 2, 2, 1 });
            var powerGrid = new PowerGrid(gridConfiguration);

            var message = powerGrid.BestLinkStationForPositionMessage(new Position(10, 10));

            Assert.AreEqual("No link station within reach for point 10, 10", message);
        }
    }
}
