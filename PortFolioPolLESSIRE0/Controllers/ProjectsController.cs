using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PortFolioPolLESSIRE0.BLL.Interfaces;
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
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IHubContext<ProjectHub> _projectHub;

        public ProjectsController(IProjectRepository projectRepository, IHubContext<ProjectHub> projectHub)
        {
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
            _projectHub = projectHub ?? throw new ArgumentNullException(nameof(projectHub));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            var projects = await _projectRepository.GetAllProjectAsync();
            return Ok(projects);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("The project ID must be a positive integer");
            }
            var project = await _projectRepository.GetByIdProjectAsync(id);

            if (project == null)
            {
                return NotFound($"No projects found with ID {id}");
            }
            return Ok(project);
        }
        [HttpPost]
        public async Task<IActionResult> AddProjectAsync(ProjectDTO project)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            // Convertir DTO en entité DAL
            var projectEntity = project.ProjectToDal();

            // Appeler la méthode async du repository
            var isAdded = await _projectRepository.AddProjectAsync(projectEntity);

            if (isAdded)
            {
                await _projectHub.Clients.All.SendAsync("notifynewproject");
                return Ok(project);
            }
            return BadRequest("Registration Error");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, string name, string description, string url, DateTime startDate, DateTime endDate)
        {
            _projectRepository.UpdateProject(id, name, description, url, startDate, endDate);
            return Ok();
        }
    }
}













//Copyrite https://github.com/POLLESSI
