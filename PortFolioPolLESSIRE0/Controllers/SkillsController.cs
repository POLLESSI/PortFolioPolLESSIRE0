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
    public class SkillsController : ControllerBase
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IHubContext<SkillHub> _skillHub;

        public SkillsController(ISkillRepository skillRepository, IHubContext<SkillHub> skillHub)
        {
            _skillRepository = skillRepository ?? throw new ArgumentNullException(nameof(skillRepository));
            _skillHub = skillHub ?? throw new ArgumentNullException(nameof(skillHub));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkills()
        {
            var skills = await _skillRepository.GetAllSkillAsync();
            return Ok(skills);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetByIdSkillAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("The skill ID must be a positive integer");
            }
            var skill = await _skillRepository.GetByIdSkillAsync(id);

            if (skill == null)
            {
                return NotFound($"No skills found with ID {id}");
            }
            return Ok(skill);
        }
        [HttpPost]
        public async Task<IActionResult> AddSkillAsync(SkillDTO skill)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            // Convertir DTO en entité DAL
            var skillEntity = skill.SkillToDal();

            // Appeler la méthode async du repository
            var isAdded = await _skillRepository.AddSkillAsync(skillEntity);

            if (isAdded)
            {
                await _skillHub.Clients.All.SendAsync("notifynewskill");
                return Ok(skill);
            }
            return BadRequest("Registration Error");
        }
    }
}
