using MarsRover.Common.Enumarations;
using MarsRover.Models.ServiceModels.RoverService;
using MarsRover.Services;
using Xunit;

namespace MarsRover.Tests.ServiceTests
{
    public class RoverServiceTests
    {
        RoverService _roverService;
        PlateauService _plateauService;

        public RoverServiceTests()
        {
            _roverService = new RoverService();
            _plateauService = new PlateauService();
        }

        [Fact]
        public void RoverCreatedSuccessXControl()
        {
            var plateau = _plateauService.Create("5 5")?.Plateau;
            RoverCreateModel roverCreateModel = _roverService.Create("1 2 N", plateau);

            Assert.Equal(1, roverCreateModel.Rover.XPosition);
        }

        [Fact]
        public void RoverCreatedSuccessYControl()
        {
            var plateau = _plateauService.Create("7 3")?.Plateau;
            RoverCreateModel roverCreateModel = _roverService.Create("1 2 N", plateau);

            Assert.Equal(2, roverCreateModel.Rover.YPosition);
        }

        [Fact]
        public void RoverCreatedSuccessDirectionControl()
        {
            var plateau = _plateauService.Create("4 2")?.Plateau;
            RoverCreateModel roverCreateModel = _roverService.Create("1 2 N", plateau);

            Assert.Equal(RoverEnums.Directions.North, roverCreateModel.Rover.Direction);
        }

        [Fact]
        public void RoverCreatedFailControl()
        {
            var plateau = _plateauService.Create("6 7")?.Plateau;
            RoverCreateModel roverCreateModel = _roverService.Create("8 3 N", plateau);

            Assert.Equal(RoverEnums.Errors.LocationNotInPlateau, roverCreateModel.ErrorDescription);
        }

        [Fact]
        public void RoverCommandsSuccessControl()
        {
            var plateau = _plateauService.Create("5 5")?.Plateau;
            RoverCreateModel roverCreateModel = _roverService.Create("1 2 N", plateau);
            RoverMovementsModel result = _roverService.RunRoverCommands(plateau, roverCreateModel.Rover, "LMLMLMLMM");

            Assert.True(result.Rover.XPosition == 1 && result.Rover.YPosition == 3 && result.Rover.Direction == RoverEnums.Directions.North);
        }

        [Fact]
        public void RoverCommandsFailControl()
        {
            var plateau = _plateauService.Create("5 5")?.Plateau;
            RoverCreateModel roverCreateModel = _roverService.Create("1 2 N", plateau);
            RoverMovementsModel result = _roverService.RunRoverCommands(plateau, roverCreateModel.Rover, "LMLMLMLMMLLMMMM");

            Assert.Equal(RoverEnums.Errors.NotValidFinalPlace, result.ErrorDescription);
        }
    }
}
