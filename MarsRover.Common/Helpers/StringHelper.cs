using MarsRover.Common.Enumarations;
using MarsRover.Models;
using MarsRover.Models.HelperModels;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarsRover.Common.Helpers
{
    public static class StringHelper
    {
        public static PlateuaSizeControlModel PlateauSizeControl(string plateuaSize)
        {
            var result = new PlateuaSizeControlModel();

            if (string.IsNullOrEmpty(plateuaSize))
            {
                result.IsSuccess = false;
                result.Description = PlateauEnums.Errors.EmptySize;
                return result;
            }

            List<string> sizeList = new List<string>();
            sizeList.AddRange(plateuaSize.Split(" "));

            if (sizeList.Count != (int)PlateauEnums.PlateauProperties.Size)
            {
                result.IsSuccess = false;
                result.Description = PlateauEnums.Errors.WrongSize;
                return result;
            }

            int x = 0, y = 0;

            result.IsSuccess = Int32.TryParse(sizeList[0], out x) && Int32.TryParse(sizeList[1], out y);
            result.XLength = x;
            result.YLength = y;

            if (!result.IsSuccess)
                result.Description = PlateauEnums.Errors.WrongSize;

            return result;
        }

        public static RoverParametersControlModel RoverParametersControl(string roverParameters, Plateau plateau)
        {
            var result = new RoverParametersControlModel();

            if (string.IsNullOrEmpty(roverParameters))
            {
                result.IsSuccess = false;
                result.Description = RoverEnums.Errors.EmptyParameters;
                return result;
            }

            List<string> parameterList = new List<string>();
            parameterList.AddRange(roverParameters.Split(" "));

            if (parameterList.Count != (int)RoverEnums.Properties.ParametersCount)
            {
                result.IsSuccess = false;
                result.Description = RoverEnums.Errors.WrongParameters;
                return result;
            }

            int x = 0, y = 0;
            string direction = parameterList[2].ToUpper();
            bool directionControl = direction.Length == 1 && (direction == RoverEnums.Directions.North || direction == RoverEnums.Directions.East || direction == RoverEnums.Directions.South || direction == RoverEnums.Directions.West);

            result.IsSuccess = Int32.TryParse(parameterList[0], out x) && Int32.TryParse(parameterList[1], out y) && directionControl;
            result.XPosition = x;
            result.YPosition = y;
            result.Direction = direction;

            if (!result.IsSuccess)
                result.Description = RoverEnums.Errors.WrongParameters;

            if (result.XPosition > plateau.XLength || result.XPosition < 0 || result.YPosition > plateau.YLength || result.YPosition < 0)
            {
                result.IsSuccess = false;
                result.Description = RoverEnums.Errors.LocationNotInPlateau;
            }

            if (!directionControl)
            {
                result.Description = RoverEnums.Errors.NotValidRoverDirection;
            }

            return result;
        }

        public static string MovementsControl(string movements)
        {
            if (string.IsNullOrEmpty(movements))
                return string.Empty;

            movements = movements.Trim().ToUpper();

            bool stringControl = Regex.IsMatch(movements, $"^[{RoverEnums.Commands.SpinLeft}{RoverEnums.Commands.SpinRight}{RoverEnums.Commands.MoveForward}]*$");

            if (!stringControl)
                return String.Empty;
            else
                return movements;
        }
    }
}
