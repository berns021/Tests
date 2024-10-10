using ElevatorManagementSystem.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace ElevatorSystemManagementTests
{
    [TestClass]
    public class ElevatorTests
    {
        [TestMethod]
        public void Elevator_InitialFloor_ShouldBeOne()
        {
            // Arrange
            Elevator elevator = new Elevator(1, 10);

            // Act
            int initialFloor = elevator.CurrentFloor;

            // Assert
            Assert.AreEqual(1, initialFloor);
        }

        [TestMethod]
        public void Elevator_AddRequest_ShouldUpdateTargetFloors()
        {
            // Arrange
            Elevator elevator = new Elevator(1, 10);

            // Act
            elevator.AddRequest(5, true);

            // Assert
            Assert.AreEqual(1, elevator.TargetFloors.Count);
            Assert.AreEqual(5, elevator.TargetFloors.First());
        }

        [TestMethod]
        public void Elevator_DistanceTo_ShouldReturnCorrectDistance()
        {
            // Arrange
            Elevator elevator = new Elevator(1, 10);
            elevator.CurrentFloor = 3;

            // Act
            int distance = elevator.DistanceTo(7);

            // Assert
            Assert.AreEqual(4, distance);
        }

        [TestMethod]
        public void Elevator_IsGoingInDirection_Up_ShouldReturnTrue()
        {
            // Arrange
            Elevator elevator = new Elevator(1, 10);
            elevator.CurrentFloor = 3;

            // Act
            bool isGoingUp = elevator.IsGoingInDirection(true, 7);

            // Assert
            Assert.IsTrue(isGoingUp);
        }

        [TestMethod]
        public void Elevator_IsGoingInDirection_Down_ShouldReturnFalse()
        {
            // Arrange
            Elevator elevator = new Elevator(1, 10);
            elevator.CurrentFloor = 7;

            // Act
            bool isGoingUp = elevator.IsGoingInDirection(true, 3);

            // Assert
            Assert.IsFalse(isGoingUp);
        }

        [TestMethod]
        public void Elevator_MoveToFloor_ShouldReachTargetFloor()
        {
            // Arrange
            Elevator elevator = new Elevator(1, 10);

            // Act
            Task.Run(() => elevator.MoveToFloor(5)).Wait();

            // Assert
            Assert.AreEqual(5, elevator.CurrentFloor);
        }
    }
}
