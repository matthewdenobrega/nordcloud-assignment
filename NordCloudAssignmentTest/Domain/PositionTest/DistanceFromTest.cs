using Microsoft.VisualStudio.TestTools.UnitTesting;
using NordCloudAssignment.Domain;
using System;

namespace NordCloudAssignmentTest.Domain.PositionTest
{
    [TestClass]
    public class DistanceFromTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Distance_from_should_throw_argument_exception_if_no_position_supplied()
        {
            var position = new Position(0, 0);

            position.DistanceFrom(null);
        }

        [TestMethod]
        public void Distance_from_should_identify_that_there_is_no_distance_between_colocated_points()
        {
            var position = new Position(0, 0);

            var distance = position.DistanceFrom(new Position(0,0));

            Assert.AreEqual(0, distance);
        }

        [TestMethod]
        public void Distance_from_calculate_the_correct_distance_between_separated_points()
        {
            var position = new Position(0, 0);

            var distance = position.DistanceFrom(new Position(3, 4));

            Assert.AreEqual(5, distance);
        }
    }
}
