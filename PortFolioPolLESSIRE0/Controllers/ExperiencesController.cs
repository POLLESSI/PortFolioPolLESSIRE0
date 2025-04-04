using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PortFolioPolLESSIRE0.BLL.Interfaces;
using PortFolioPolLESSIRE0.BLL.Services;
using PortFolioPolLESSIRE0.DAL.Entities;
using PortFolioPolLESSIRE0.DAL.Interfaces;
using PortFolioPolLESSIRE0.DAL.Repositories;
using PortFolioPolLESSIRE0.DTOs;
using PortFolioPolLESSIRE0.Tools;
using PortFolioPolLESSIRE1.API.Hubs;

namespace PortFolioPolLESSIRE0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        private readonly IExperienceRepository _experiencesRepository;
        private readonly IHubContext<ExperienceHub> _experienceHub;

        public ExperiencesController(IExperienceRepository experiencesRepository, IHubContext<ExperienceHub> experienceHub)
        {
            _experiencesRepository = experiencesRepository ?? throw new ArgumentNullException(nameof(experiencesRepository));
            _experienceHub = experienceHub ?? throw new ArgumentNullException(nameof(experienceHub));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experience>>> GetExperiences()
        {
            var experiences = await _experiencesRepository.GetAllExperiencesAsync();
            return Ok(experiences);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Experience>> GetByIdExperienceAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("The experience ID must be a positive integer");
            }
            var experience = await _experiencesRepository.GetByIdExperienceAsync(id);

            if (experience == null)
            {
                return NotFound($"No experiences found with ID {id}");
            }
            return Ok(experience);
        }
        [HttpPost]
        public async Task<IActionResult> AddExperienceAsync(ExperienceDTO experience)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            // Convertir DTO en entité DAL
            var experienceEntity = experience.ExperienceToDal();

            // Appeler la méthode async du repository
            var isAdded = await _experiencesRepository.AddExperienceAsync(experienceEntity);

            if (isAdded)
            {
                await _experienceHub.Clients.All.SendAsync("notifynewexperience");
                return Ok(experience);
            }
            return BadRequest("Registration Error");
        }
    }
}
