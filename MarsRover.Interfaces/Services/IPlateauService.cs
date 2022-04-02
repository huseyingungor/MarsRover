using MarsRover.Models.ServiceModels.PlateuaService;

namespace MarsRover.Interfaces.Services
{
    public  interface IPlateauService
    {
        PlateuaCreateModel Create(string plateuaSize);
    }
}
