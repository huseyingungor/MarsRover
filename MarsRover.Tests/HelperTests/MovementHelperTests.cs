using MarsRover.Common.Enumarations;
using MarsRover.Common.Helpers;
using MarsRover.Models;
using Xunit;

namespace MarsRover.Tests.HelperTests
{
    public class MovementHelperTests
    {
        [Fact]
        public void WestSpinRightSuccess()
        {
            Assert.Equal(RoverEnums.Directions.North, MovementsHelper.SpinRight(RoverEnums.Directions.West));
        }

        [Fact]
        public void SouthSpinRightSuccess()
        {
            Assert.Equal(RoverEnums.Directions.West, MovementsHelper.SpinRight(RoverEnums.Directions.South));
        }

        [Fact]
        public void EastSpinLeftSuccess()
        {
            Assert.Equal(RoverEnums.Directions.North, MovementsHelper.SpinLeft(RoverEnums.Directions.East));
        }

        [Fact]
        public void NorthSpinLeftSuccess()
        {
            Assert.Equal(RoverEnums.Directions.West, MovementsHelper.SpinLeft(RoverEnums.Directions.North));
        }

        [Fact]
        public void WestForwardSuccess()
        {
            Rover rover = new Rover(3, 5, RoverEnums.Directions.West);
            MovementsHelper.Forward(ref rover);

            Assert.Equal(2, rover.XPosition);
        }

        [Fact]
        public void NorthForwardSuccess()
        {
            Rover rover = new Rover(3, 5, RoverEnums.Directions.North);
            MovementsHelper.Forward(ref rover);

            Assert.Equal(6, rover.YPosition);
        }

        [Fact]
        public void NotValidCommandsTrue()
        {
            Rover rover = new Rover(3, 5, RoverEnums.Directions.North);
            bool isSuccess = MovementsHelper.CommandsAreValid(rover);

            Assert.True(isSuccess);
        }

        [Fact]
        public void NotValidXPositionCommandsFalse()
        {
            Rover rover = new Rover(-1, 5, RoverEnums.Directions.North);
            bool isSuccess = MovementsHelper.CommandsAreValid(rover);

            Assert.False(isSuccess);
        }

        [Fact]
        public void NotValidYPositionCommandsFalse()
        {
            Rover rover = new Rover(3, -1, RoverEnums.Directions.North);
            bool isSuccess = MovementsHelper.CommandsAreValid(rover);

            Assert.False(isSuccess);
        }
    }
}
