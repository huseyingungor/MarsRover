using MarsRover.Common.Enumarations;
using MarsRover.Common.Helpers;
using MarsRover.Interfaces.Services;
using MarsRover.Models;
using System;

namespace MarsRover.ServiceCallHelpers
{
    public static class RoverServiceCallHelper
    {
        /// <summary>
        /// Call RoverService for create rover. Using "for loop" for try again if input is not valid.
        /// </summary>
        /// <param name="_roverService"></param>
        /// <param name="plateau"></param>
        /// <returns></returns>
        public static Rover CreateRover(IRoverService _roverService, Plateau plateau)
        {
            Rover result = new Rover(0, 0, RoverEnums.Directions.North);

            for (int i = 0; i < int.MaxValue; i++)
            {
                string roverParameters = Console.ReadLine();

                var roverCreateResult = _roverService.Create(roverParameters, plateau);

                if (roverCreateResult.IsSuccess)
                {
                    result = roverCreateResult.Rover;
                    break;
                }
                else
                {
                    Console.WriteLine(roverCreateResult.ErrorDescription);
                }
            }

            return result;
        }

        /// <summary>
        /// Run rover movement commands. Using "for loop" for try again if input is not valid.
        /// </summary>
        /// <param name="_roverService"></param>
        /// <param name="plateau"></param>
        /// <param name="rover"></param>
        public static void GetAndRunCommands(IRoverService _roverService, Plateau plateau, Rover rover)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                string commands = Console.ReadLine();
                commands = StringHelper.MovementsControl(commands);

                if (string.IsNullOrEmpty(commands))
                {
                    Console.WriteLine(RoverEnums.Errors.NotValidCommands);
                    continue;
                }

                var result = _roverService.RunRoverCommands(plateau, rover, commands);

                if (result.IsSuccess)
                {
                    Console.WriteLine($"{result.Rover.XPosition} {result.Rover.YPosition} {result.Rover.Direction}");
                    break;
                }
                else
                {
                    Console.WriteLine(result.ErrorDescription);
                }
            }
        }
    }
}
