namespace MarsRover.Common.Enumarations
{
    public class RoverEnums
    {
        public static class Directions
        {
            public const string North = "N";
            public const string East = "E";
            public const string South = "S";
            public const string West = "W";
        }

        public static class Errors
        {
            public const string EmptyParameters = "Rover parameters are not valid! Try again.";
            public const string WrongParameters = "Rover cannot be created! Try again.";
            public const string LocationNotInPlateau = "Rover location is not in plateau! Try again.";
            public const string NotValidRoverPosition = "Rover position is not valid! Try again.";
        }

        public enum Properties
        {
            ParametersCount = 3
        }
    }
}
