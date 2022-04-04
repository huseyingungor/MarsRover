namespace MarsRover.Common.Enumarations
{
    public  class PlateauEnums
    {
        public enum PlateauProperties
        {
            Size = 2
        }

        public static class Errors
        {
            public const string WrongSize = "Plateau size is not valid! Try again.";
            public const string EmptySize = "Plateau size cannot be empty! Try again.";
        }
    }
}
