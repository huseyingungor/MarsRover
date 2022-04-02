using MarsRover.Common.Helpers;
using MarsRover.Interfaces.Services;
using MarsRover.Models;
using MarsRover.Models.ServiceModels.RoverService;

namespace MarsRover.Services
{
    public class RoverService : IRoverService
    {
        public RoverCreateModel Create(string roverCreateParameters, Plateau plateau)
        {
            RoverCreateModel result = new RoverCreateModel();

            var inputControlResult = StringHelpers.RoverParametersControl(roverCreateParameters, plateau);

            result.IsSuccess = inputControlResult.IsSuccess;
            result.ErrorDescription = inputControlResult.Description;

            if (inputControlResult.IsSuccess)
            {
                result.Rover = new Rover(inputControlResult.XPosition, inputControlResult.YPosition, inputControlResult.Direction);
            }

            return result;
        }
    }
}
