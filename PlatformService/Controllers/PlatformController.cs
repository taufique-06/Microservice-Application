using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.DTOs;
using PlatformService.Models;
using PlatformService.Services.Interfaces;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _platformService;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformService platformService, IMapper mapper)
        {
            _platformService = platformService;
            _mapper = mapper;
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
        public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTO platformCreateDTO)
        {
            var platFrom = _mapper.Map<Platform>(platformCreateDTO);
            _platformService.CreatePlatform(platFrom);
            _platformService.SaveChange();

            var platfromReadDto = _mapper.Map<PlatformReadDTO>(platFrom);
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
