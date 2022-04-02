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

        public static class PlateuaErrors
        {
            public const string WrongSize = "Plateau size is not valid!";
        }
    }
}
