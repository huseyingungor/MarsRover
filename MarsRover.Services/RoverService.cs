using MarsRover.Common.Enumarations;
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

            var inputControlResult = StringHelper.RoverParametersControl(roverCreateParameters, plateau);

            result.IsSuccess = inputControlResult.IsSuccess;
            result.ErrorDescription = inputControlResult.Description;

            if (inputControlResult.IsSuccess)
            {
                result.Rover = new Rover(inputControlResult.XPosition, inputControlResult.YPosition, inputControlResult.Direction);
            }

            return result;
        }

        public RoverMovementsModel RunRoverCommands(Plateau plateau, Rover rover, string commands)
        {
            RoverMovementsModel result = new RoverMovementsModel();

            foreach (var movement in commands)
            {
                switch (movement)
                {
                    case RoverEnums.Commands.SpinLeft: rover.Direction = MovementsHelper.SpinLeft(rover.Direction); break;
                    case RoverEnums.Commands.SpinRight: rover.Direction = MovementsHelper.SpinRight(rover.Direction); break;
                    case RoverEnums.Commands.MoveForward: MovementsHelper.Forward(ref rover); break;
                    default:
                        break;
                }
            }

            result.IsSuccess = MovementsHelper.CommandsAreValid(rover);
            result.Rover = rover;

            if (!result.IsSuccess)
            {
                result.ErrorDescription = RoverEnums.Errors.NotValidFinalPlace;
            }

            return result;
        }
    }
}
