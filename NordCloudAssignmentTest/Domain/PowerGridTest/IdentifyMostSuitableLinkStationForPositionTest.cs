using Microsoft.VisualStudio.TestTools.UnitTesting;
using NordCloudAssignment.Domain;
using System;
using System.Collections.Generic;

namespace NordCloudAssignmentTest.Domain.PowerGridTest
{
    [TestClass]
    public class IdentifyMostSuitableLinkStationForPositionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Identify_most_suitable_link_station_for_position_should_throw_argument_exception_if_no_position_is_supplied()
        {
            var gridConfiguration = new List<List<double>>();
            gridConfiguration.Add(new List<double>() { 0, 0, 1 });
            var powerGrid = new PowerGrid(gridConfiguration);

            powerGrid.IdentifyMostSuitableLinkStationForPosition(null);
        }

        [TestMethod]
        public void Identify_most_suitable_link_station_for_position_should_identify_the_most_suitable_link_station()
        {
            var gridConfiguration = new List<List<double>>();
            gridConfiguration.Add(new List<double>() { 0, 0, 1 });
            gridConfiguration.Add(new List<double>() { 2, 2, 1 });
            var powerGrid = new PowerGrid(gridConfiguration);

            var linkStationWithPower = powerGrid.IdentifyMostSuitableLinkStationForPosition(new Position(2, 2));

            Assert.AreEqual(2, linkStationWithPower.Item1.Position.X);
            Assert.AreEqual(2, linkStationWithPower.Item1.Position.Y);
        }

        [TestMethod]
        public void Identify_most_suitable_link_station_for_position_should_identify_the_power_of_most_suitable_link_station()
        {
            var gridConfiguration = new List<List<double>>();
            gridConfiguration.Add(new List<double>() { 0, 0, 1 });
            gridConfiguration.Add(new List<double>() { 2, 2, 2 });
            var powerGrid = new PowerGrid(gridConfiguration);

            var linkStationWithPower = powerGrid.IdentifyMostSuitableLinkStationForPosition(new Position(2, 2));

            Assert.AreEqual(4, linkStationWithPower.Item2);
        }

        [TestMethod]
        public void Identify_most_suitable_link_station_for_position_should_identify_if_no_link_station_is_within_range()
        {
            var gridConfiguration = new List<List<double>>();
            gridConfiguration.Add(new List<double>() { 0, 0, 1 });
            gridConfiguration.Add(new List<double>() { 2, 2, 1 });
            var powerGrid = new PowerGrid(gridConfiguration);

            var linkStationWithPower = powerGrid.IdentifyMostSuitableLinkStationForPosition(new Position(5, 5));

            Assert.IsNull(linkStationWithPower);
        }
    }
}
