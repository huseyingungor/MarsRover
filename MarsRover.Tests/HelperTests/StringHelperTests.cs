using MarsRover.Common.Enumarations;
using MarsRover.Common.Helpers;
using MarsRover.Services;
using System;
using Xunit;

namespace MarsRover.Tests.HelperTests
{
    public class StringHelperTests
    {
        PlateauService _plateauService;

        public StringHelperTests()
        {
            _plateauService = new PlateauService();
        }

        [Fact]
        public void PlateautSizeSuccess()
        {
            var result = StringHelper.PlateauSizeControl("3 4");

            Assert.True(result.XLength == 3 && result.YLength == 4);
        }

        [Fact]
        public void PlateautSizeEmpty()
        {
            var result = StringHelper.PlateauSizeControl(String.Empty);

            Assert.True(!result.IsSuccess && result.Description == PlateauEnums.Errors.EmptySize);
        }

        [Fact]
        public void PlateautSizeNull()
        {
            var result = StringHelper.PlateauSizeControl(null);

            Assert.True(!result.IsSuccess && result.Description == PlateauEnums.Errors.EmptySize);
        }

        [Fact]
        public void WrongPlateautSize()
        {
            var result = StringHelper.PlateauSizeControl("5 5 3");

            Assert.True(!result.IsSuccess && result.Description == PlateauEnums.Errors.WrongSize);
        }

        [Fact]
        public void WrongPlateautSizeString()
        {
            var result = StringHelper.PlateauSizeControl("XY");

            Assert.True(!result.IsSuccess && result.Description == PlateauEnums.Errors.WrongSize);
        }

        [Fact]
        public void RoverParametersSuccess()
        {
            var plateau = _plateauService.Create("5 5")?.Plateau;
            var result = StringHelper.RoverParametersControl("1 2 N", plateau);

            Assert.True(result.XPosition == 1 && result.YPosition == 2 && result.Direction == RoverEnums.Directions.North);
        }

        [Fact]
        public void RoverParametersEmpty()
        {
            var plateau = _plateauService.Create("5 5")?.Plateau;
            var result = StringHelper.RoverParametersControl(string.Empty, plateau);

            Assert.True(!result.IsSuccess && result.Description == RoverEnums.Errors.EmptyParameters);
        }

        [Fact]
        public void RoverParametersNull()
        {
            var plateau = _plateauService.Create("5 5")?.Plateau;
            var result = StringHelper.RoverParametersControl(null, plateau);

            Assert.True(!result.IsSuccess && result.Description == RoverEnums.Errors.EmptyParameters);
        }

        [Fact]
        public void RoverExtraParameters()
        {
            var plateau = _plateauService.Create("5 5")?.Plateau;
            var result = StringHelper.RoverParametersControl("1 2 N 1", plateau);

            Assert.True(!result.IsSuccess && result.Description == RoverEnums.Errors.WrongParameters);
        }

        [Fact]
        public void RoverNotInPlateau()
        {
            var plateau = _plateauService.Create("5 5")?.Plateau;
            var result = StringHelper.RoverParametersControl("6 5 N", plateau);

            Assert.True(!result.IsSuccess && result.Description == RoverEnums.Errors.LocationNotInPlateau);
        }

        [Fact]
        public void RoverWrongDirection()
        {
            var plateau = _plateauService.Create("5 5")?.Plateau;
            var result = StringHelper.RoverParametersControl("3 5 C", plateau);

            Assert.True(!result.IsSuccess && result.Description == RoverEnums.Errors.NotValidRoverDirection);
        }

        [Fact]
        public void MovementsSuccess()
        {
            string movements = "LMLMLMLMM";

            Assert.Equal(movements, StringHelper.MovementsControl(movements));
        }

        [Fact]
        public void WrongMovements()
        {
            string movements = "LMCDLM";

            Assert.NotEqual(movements, StringHelper.MovementsControl(movements));
        }
    }
}
