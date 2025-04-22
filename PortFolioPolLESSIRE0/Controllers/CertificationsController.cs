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
    //[Route("api/[controller]")]
    [Route("api/certifications")]
    [ApiController]
    public class CertificationsController : ControllerBase
    {
        private readonly ICertificationRepository _certificationRepository;
        private readonly IHubContext<CertificationHub> _certificationHub;

        public CertificationsController(ICertificationRepository certificationRepository, IHubContext<CertificationHub> certificationHub)
        {
            _certificationRepository = certificationRepository ?? throw new ArgumentNullException(nameof(certificationRepository));
            _certificationHub = certificationHub ?? throw new ArgumentNullException(nameof(certificationHub));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Certification>>> GetCertifications()
        {
            var certifications = await _certificationRepository.GetAllCertificationsAsync();
            return Ok(certifications);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Certification>> GetByIdCertificationAsync(int id)
        {
            Console.WriteLine($"[DEBUG] Appel GetByIdCertificationAsync with id={id}"); // 🔍 log console
            if (id <= 0)
            {
                return BadRequest("The certification ID must be a positive integer");
            }
            var certification = await _certificationRepository.GetByIdCertificationAsync(id);

            if (certification == null)
            {
                return NotFound($"No projects found with ID {id}");
            }
            return Ok(certification);
        }
        [HttpPost]
        public async Task<IActionResult> AddCertificationAsync(CertificationDTO certification)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid certification data");

            // Convertir DTO en entité DAL
            var certificationEntity = certification.CertificationToDal();

            // Appeler la méthode async du repository
            var isAdded = await _certificationRepository.AddCertificationAsync(certificationEntity);

            if (isAdded)
            {
                await _certificationHub.Clients.All.SendAsync("notifynewcertification");
                return Ok(certification);
            }

            return BadRequest("Registration error");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCertification(int id, string name, string authority, string licenceNumber, string url, DateTime licenceDate)
        {
            _certificationRepository.UpdateCertification(id, name, authority, licenceNumber, url, licenceDate);
            return Ok();
        }
    }

















    //Copyrite https://github.com/POLLESSI
}
