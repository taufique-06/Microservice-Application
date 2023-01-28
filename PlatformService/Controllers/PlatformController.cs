using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.DTOs;
using PlatformService.Models;
using PlatformService.Services.Interfaces;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _platformService;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformController(IPlatformService platformService, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _platformService = platformService;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetAllPlatforms()
        {
            var allPlatform = _platformService.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(allPlatform));
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatformsById(int id)
        {
            var platform = _platformService.GetPlatformsById(id);
            if (platform != null) return Ok(_mapper.Map<PlatformReadDTO>(platform));

            return NotFound();
        }

        [HttpPost]
        public async Task <ActionResult<PlatformReadDTO>> CreatePlatform(PlatformCreateDTO platformCreateDTO)
        {
            var platFrom = _mapper.Map<Platform>(platformCreateDTO);
            _platformService.CreatePlatform(platFrom);
            _platformService.SaveChange();

            var platfromReadDto = _mapper.Map<PlatformReadDTO>(platFrom);

            try
            {
                await _commandDataClient.SendPlatformToCommand(platfromReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not send the message: {ex.Message}");
            }
            return new PlatformReadDTO
            {
                Id = platfromReadDto.Id,
                Cost = platfromReadDto.Cost,
                Name = platfromReadDto.Name,
                Publisher = platfromReadDto.Publisher
            };
        }
    }
}
