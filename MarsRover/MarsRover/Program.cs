using MarsRover.Common.Enumarations;
using MarsRover.Interfaces.Services;
using MarsRover.Models;
using MarsRover.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover
{
    internal class Program
    {
        static IPlateauService _plateauService;
        static IRoverService _roverService;

        static void Main(string[] args)
        {
            ServiceProvider provider = new ServiceCollection()
                .AddSingleton<IPlateauService, PlateauService>()
                .AddSingleton<IRoverService, RoverService>()
                .BuildServiceProvider();

            _plateauService = provider.GetService<IPlateauService>();
            _roverService = provider.GetService<IRoverService>();

            Plateau plateau = CreatePlateau();

            //kaç adet rover olacağı belli olmadığı için
            for (int i = 1; i < int.MaxValue; i++)
            {
                Rover rover = CreateRover(plateau);
                Console.WriteLine($"{i}. Rover coordinate: X:{rover.XPosition} - Y:{rover.YPosition} - Direction:{rover.Direction}");
            }

            Console.WriteLine($"Plateau Size: {plateau.XLength} - {plateau.YLength}");
            Console.ReadKey();
        }

        /// <summary>
        /// Call PlateauService for create plateau. Using "for loop" for try again if input is not valid.
        /// </summary>
        /// <returns></returns>
        public static Plateau CreatePlateau()
        {
            Plateau result = new Plateau(0, 0);

            for (int i = 0; i < int.MaxValue; i++)
            {
                string plateauSize = Console.ReadLine();

                var plateauSizeResult = _plateauService.Create(plateauSize);

                if (plateauSizeResult.IsSuccess)
                {
                    result = plateauSizeResult.Plateau;
                    break;
                }
                else
                {
                    Console.WriteLine(plateauSizeResult.ErrorDescription);
                }
            }

            return result;
        }

        /// <summary>
        /// Call RoverService for create rover. Using "for loop" for try again if input is not valid.
        /// </summary>
        /// <returns></returns>
        public static Rover CreateRover(Plateau plateau)
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
    }
}
