using Microsoft.VisualStudio.TestTools.UnitTesting;
using NordCloudAssignment.Domain;
using System;
using System.Collections.Generic;

namespace NordCloudAssignmentTest.Domain.PowerGridTest
{
    [TestClass]
    public class ConstructorTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Power_grid_constructor_should_throw_argument_exception_if_no_configuration_supplied()
        {
            new PowerGrid(null);
        }

        [TestMethod]
        public void Power_grid_constructor_should_create_any_empty_grid_for_an_empty_config()
        {
            var gridConfig = new List<List<double>>();

            var powerGrid = new PowerGrid(gridConfig);

            Assert.AreEqual(0, powerGrid.NumberOfLinkStations());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Power_grid_constructor_should_throw_an_argument_exception_if_the_grid_config_has_too_few_fields()
        {
            var gridConfig = new List<List<double>>();
            gridConfig.Add(new List<double>() { 1, 2 });

            new PowerGrid(gridConfig);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Power_grid_constructor_should_throw_an_argument_exception_if_the_grid_config_has_two_many_fields()
        {
            var gridConfig = new List<List<double>>();
            gridConfig.Add(new List<double>() { 1, 2, 3, 4 });

            new PowerGrid(gridConfig);
        }

        [TestMethod]
        public void Power_grid_constructor_should_create_a_new_power_grid_from_a_correct_config()
        {
            var gridConfig = new List<List<double>>();
            gridConfig.Add(new List<double>() { 1, 2, 3 });
            gridConfig.Add(new List<double>() { 4, 5, 6 });

            var powerGrid = new PowerGrid(gridConfig);

            Assert.AreEqual(2, powerGrid.NumberOfLinkStations());
        }
    }
}
