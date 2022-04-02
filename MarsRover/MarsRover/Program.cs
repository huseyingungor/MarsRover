using MarsRover.Interfaces.Services;
using MarsRover.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider provider = new ServiceCollection()
                .AddSingleton<IPlateauService, PlateauService>()
                .BuildServiceProvider();

            IPlateauService _plateauService = provider.GetService<IPlateauService>();

            string plateauSize = Console.ReadLine();

            var plateauSizeResult = _plateauService.Create(plateauSize);
            if (!plateauSizeResult.IsSuccess)
            {
                Console.WriteLine(plateauSizeResult.ErrorDescription);
                return;
            }

            Console.WriteLine($"X:{plateauSizeResult.Plateau.XLength} - Y:{plateauSizeResult.Plateau.YLength}");
            Console.ReadKey();
        }
    }
}
