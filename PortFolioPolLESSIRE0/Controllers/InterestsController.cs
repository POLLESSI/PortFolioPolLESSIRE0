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
    public class InterestsController : ControllerBase
    {
        private readonly IInterestRepository _interestRepository;
        private readonly IHubContext<InterestHub> _interestHub;

        public InterestsController(IInterestRepository interestRepository, IHubContext<InterestHub> interestHub)
        {
            _interestRepository = interestRepository ?? throw new ArgumentNullException(nameof(interestRepository));
            _interestHub = interestHub ?? throw new ArgumentNullException(nameof(interestHub));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interest>>> GetInterests()
        {
            var interests = await _interestRepository.GetAllInterestsAsync();
            return Ok(interests);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Interest>> GetByIdInterestAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("The interest ID must be a positive integer");
            }
            var interest = await _interestRepository.GetByIdInterestAsync(id);

            if (interest == null)
            {
                return NotFound($"No interests found with ID {id}");
            }
            return Ok(interest);
        }
        [HttpPost]
        public async Task<IActionResult> AddInterestAsync(InterestDTO interest)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            // Convertir DTO en entité DAL
            var interestEntity = interest.InterestToDal();

            // Appeler la méthode async du repository
            var isAdded = await _interestRepository.AddInterestAsync(interestEntity);

            if (isAdded)
            {
                await _interestHub.Clients.All.SendAsync("notifynewinterest");
                return Ok(interest);
            }
            return BadRequest("Registration Error");

        }
    }
}
