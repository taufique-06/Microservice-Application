using PlatformService.Models;

namespace PlatformService.Services.Interfaces
{
    public interface IPlatformService
    {
        bool SaveChange();

        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformsById(int id); 
        void CreatePlatform(Platform platform);
    }
}
