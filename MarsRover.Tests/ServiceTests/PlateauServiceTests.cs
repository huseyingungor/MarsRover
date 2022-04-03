using MarsRover.Models.ServiceModels.PlateuaService;
using MarsRover.Services;
using Xunit;

namespace MarsRover.Tests
{
    public class PlateauServiceTests
    {
        [Fact]
        public void CreatePlateauXValueEqual()
        {
            PlateauService service = new PlateauService();
            PlateuaCreateModel model = service.Create("3 5");

            Assert.Equal(3, model.Plateau.XLength);
        }

        [Fact]
        public void CreatePlateauYValueEqual()
        {
            PlateauService service = new PlateauService();
            PlateuaCreateModel model = service.Create("3 5");

            Assert.Equal(5, model.Plateau.YLength);
        }

        [Fact]
        public void CreatePlateauErrorControl()
        {
            PlateauService service = new PlateauService();
            PlateuaCreateModel model = service.Create("3 5 5");

            Assert.True(model.Plateau == null && model.IsSuccess == false);
        }
    }
}
