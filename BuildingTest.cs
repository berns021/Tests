using ElevatorManagementSystem.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElevatorManagementSystem.Tests
{
    [TestClass]
    public class BuildingTests
    {
        [TestMethod]
        public void Building_Initialization_SetsCorrectProperties()
        {
            // Arrange
            int floors = 10;
            int elevatorCount = 2;

            // Act
            Building building = new Building(floors, elevatorCount);

            // Assert
            Assert.AreEqual(floors, building.Floors);
            Assert.AreEqual(elevatorCount, building.Elevators.Count);
            foreach (var elevator in building.Elevators)
            {
                Assert.AreEqual(floors, elevator.Floors);
            }
        }

        [TestMethod]
        public void SelectElevator_ReturnsClosestElevator()
        {
            // Arrange
            int floors = 10;
            Building building = new Building(floors, 3);

            // Act
            building.Elevators[0].CurrentFloor = 1; // First elevator is on the ground floor
            building.Elevators[1].CurrentFloor = 5; // Second elevator is on the fifth floor
            building.Elevators[2].CurrentFloor = 10; // Third elevator is on the top floor

            Elevator selectedElevator = building.SelectElevator(3, true); // Requesting floor 3, going up

            // Assert
            Assert.AreEqual(1, selectedElevator.CurrentFloor); // Should select the first elevator
        }

    }
}
