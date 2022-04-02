using MarsRover.Common.Enumarations;
using MarsRover.Models.HelperModels;
using System;
using System.Collections.Generic;

namespace MarsRover.Common.Helpers
{
    public static class StringHelpers
    {
        public static PlateuaSizeControlModel PlateuaSizeControl(string plateuaSize)
        {
            var result = new PlateuaSizeControlModel();

            if (string.IsNullOrEmpty(plateuaSize))
            {
                result.IsSuccess = false;
                result.Description = PlateuaEnums.PlateuaErrors.WrongSize;
                return result;
            }

            List<string> sizeList = new List<string>();
            sizeList.AddRange(plateuaSize.Split(" "));

            if (sizeList.Count != (int)PlateuaEnums.PlateuaProperties.Size)
            {
                result.IsSuccess = false;
                result.Description = PlateuaEnums.PlateuaErrors.WrongSize;
                return result;
            }

            int x = 0, y = 0;

            result.IsSuccess = Int32.TryParse(sizeList[0], out x) && Int32.TryParse(sizeList[1], out y);
            result.XLength = x;
            result.YLength = y;

            return result;
        }
    }
}
