using MarsRover.Interfaces.Services;
using MarsRover.Models;
using MarsRover.ServiceCallHelpers;
using MarsRover.Services;
using Microsoft.Extensions.DependencyInjection;

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

            Plateau plateau = PlateauServiceCallHelper.CreatePlateau(_plateauService);

            //It is not clear how many rovers there are.
            for (int i = 1; i < int.MaxValue; i++)
            {
                Rover rover = RoverServiceCallHelper.CreateRover(_roverService, plateau);
                RoverServiceCallHelper.GetAndRunCommands(_roverService, plateau, rover);
            }
        }
    }
}