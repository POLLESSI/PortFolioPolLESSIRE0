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
    public class EducationsController : ControllerBase
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IHubContext<EducationHub> _educationHub;

        public EducationsController(IEducationRepository educationRepository, IHubContext<EducationHub> educationHub)
        {
            _educationRepository = educationRepository ?? throw new ArgumentNullException(nameof(educationRepository));
            _educationHub = educationHub ?? throw new ArgumentNullException(nameof(educationHub));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> GetEducations()
        {
            var educations = await _educationRepository.GetAllEducationsAsync();
            return Ok(educations);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Education>> GetByIdEducationAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("The education ID must be a positive integer");
            }
            var education = await _educationRepository.GetByIdEducationAsync(id);

            if (education == null)
            {
                return NotFound($"No projects found with ID {id}");
            }
            return Ok(education);
        }
        [HttpPost]
        public async Task<IActionResult> AddEducationAsync(EducationDTO education)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            // Convertir DTO en entité DAL
            var educationEntity = education.EducationToDal();

            // Appeler la méthode async du repository
            var isAdded = await _educationRepository.AddEducationAsync(educationEntity);

            if (isAdded)
            {
                await _educationHub.Clients.All.SendAsync("notifyneweducation");
                return Ok(education);
            }
            return BadRequest("Registration Error");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEducation(int id, string school, string fieldOfStudy, DateTime startDate, DateTime endDate, string description)
        {
            _educationRepository.UpdateEducation(id, school, fieldOfStudy, startDate, endDate, description);
            return Ok();
        }
    }
}













//Copyrite https://github.com/POLLESSI
