using PlatformService.Data;
using PlatformService.Models;
using PlatformService.Services.Interfaces;

namespace PlatformService.Services
{
    public class PlatformServiceClass : IPlatformService
    {
        private readonly PlatfromDbContext _context;
        public PlatformServiceClass(PlatfromDbContext db)
        {
            _context = db;
        }
        public void CreatePlatform(Platform platform)
        {
            if (platform == null)  throw new ArgumentNullException(nameof(platform));

            _context.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformsById(int id)
        {
            return _context.Platforms.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
