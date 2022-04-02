using MarsRover.Common.Helpers;
using MarsRover.Interfaces.Services;
using MarsRover.Models;
using MarsRover.Models.ServiceModels.PlateuaService;

namespace MarsRover.Services
{
    public class PlateauService : IPlateauService
    {
        public PlateuaCreateModel Create(string plateuaSize)
        {
            PlateuaCreateModel result = new PlateuaCreateModel();

            var inputControlResult = StringHelpers.PlateuaSizeControl(plateuaSize);
            result.IsSuccess = inputControlResult.IsSuccess;
            result.ErrorDescription = inputControlResult.Description;

            if (inputControlResult.IsSuccess)
            {
                result.Plateau = new Plateau(inputControlResult.XLength, inputControlResult.YLength);
            }

            return result;
        }
    }
}
