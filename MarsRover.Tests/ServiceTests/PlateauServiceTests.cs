using MarsRover.Models.ServiceModels.PlateuaService;
using MarsRover.Services;
using Xunit;

namespace MarsRover.Tests
{
    public class PlateauServiceTests
    {
        PlateauService _plateauService;

        public PlateauServiceTests()
        {
            _plateauService = new PlateauService();
        }

        [Fact]
        public void CreatePlateauXValueEqual()
        {
            PlateuaCreateModel model = _plateauService.Create("3 5");

            Assert.Equal(3, model.Plateau.XLength);
        }

        [Fact]
        public void CreatePlateauYValueEqual()
        {
            PlateuaCreateModel model = _plateauService.Create("3 5");

            Assert.Equal(5, model.Plateau.YLength);
        }

        [Fact]
        public void CreatePlateauErrorControl()
        {
            PlateuaCreateModel model = _plateauService.Create("3 5 5");

            Assert.True(model.Plateau == null && model.IsSuccess == false);
        }
    }
}
