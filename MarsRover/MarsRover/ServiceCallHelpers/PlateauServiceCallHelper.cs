using MarsRover.Interfaces.Services;
using MarsRover.Models;
using System;

namespace MarsRover.ServiceCallHelpers
{
    public static class PlateauServiceCallHelper
    {
        /// <summary>
        /// Call PlateauService for create plateau. Using "for loop" for try again if input is not valid.
        /// </summary>
        /// <param name="_service"></param>
        /// <returns></returns>
        public static Plateau CreatePlateau(IPlateauService _plateauService)
        {
            Plateau result = new Plateau(0, 0);

            string plateauSize = Console.ReadLine();

            var plateauSizeResult = _plateauService.Create(plateauSize);

            if (plateauSizeResult.IsSuccess)
            {
                return plateauSizeResult.Plateau;
            }
            else
            {
                Console.WriteLine(plateauSizeResult.ErrorDescription);
                result = CreatePlateau(_plateauService);
            }

            return result;
        }
    }
}
