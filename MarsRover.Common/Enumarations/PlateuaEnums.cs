using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarsRover.Common.Enumarations
{
    public  class PlateuaEnums
    {
        public enum PlateuaProperties
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
