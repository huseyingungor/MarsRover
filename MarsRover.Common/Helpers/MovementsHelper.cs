using MarsRover.Common.Enumarations;
using MarsRover.Models;

namespace MarsRover.Common.Helpers
{
    public class MovementsHelper
    {
        public static string SpinRight(string roverDirection)
        {
            string newDirection = string.Empty;

            switch (roverDirection)
            {
                case RoverEnums.Directions.North: newDirection = RoverEnums.Directions.East; break;
                case RoverEnums.Directions.East: newDirection = RoverEnums.Directions.South; break;
                case RoverEnums.Directions.South: newDirection = RoverEnums.Directions.West; break;
                case RoverEnums.Directions.West: newDirection = RoverEnums.Directions.North; break;
                default:
                    break;
            }

            return newDirection;
        }

        public static string SpinLeft(string roverDirection)
        {
            string newDirection = string.Empty;

            switch (roverDirection)
            {
                case RoverEnums.Directions.North: newDirection = RoverEnums.Directions.West; break;
                case RoverEnums.Directions.West: newDirection = RoverEnums.Directions.South; break;
                case RoverEnums.Directions.South: newDirection = RoverEnums.Directions.East; break;
                case RoverEnums.Directions.East: newDirection = RoverEnums.Directions.North; break;
                default:
                    break;
            }

            return newDirection;
        }

        public static void Forward(ref Rover rover)
        {
            switch (rover.Direction)
            {
                case RoverEnums.Directions.North:
                    rover.YPosition++;
                    break;
                case RoverEnums.Directions.East:
                    rover.XPosition++;
                    break;
                case RoverEnums.Directions.South:
                    rover.YPosition--;
                    break;
                case RoverEnums.Directions.West:
                    rover.XPosition--;
                    break;
                default:
                    break;
            }
        }

        public static bool CommandsAreValid(Rover rover)
        {
            return rover.XPosition >= 0 || rover.YPosition >= 0;
        }
    }
}
