using MarsRover.Models;
using MarsRover.Models.ServiceModels.RoverService;

namespace MarsRover.Interfaces.Services
{
    public interface IRoverService
    {
        RoverCreateModel Create(string roverCreateParameters, Plateau plateau);
    }
}
