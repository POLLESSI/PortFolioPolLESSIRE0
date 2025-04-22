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
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IHubContext<LanguageHub> _languageHub;

        public LanguagesController(ILanguageRepository languageRepository, IHubContext<LanguageHub> languageHub)
        {
            _languageRepository = languageRepository ?? throw new ArgumentNullException(nameof(languageRepository));
            _languageHub = languageHub ?? throw new ArgumentNullException(nameof(languageHub));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguages()
        {
            var languages = await _languageRepository.GetAllLanguagesAsync();
            return Ok(languages);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Language>> GetByIdLanguageAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("The project ID must be a positive integer");
            }
            var language = await _languageRepository.GetByIdLanguageAsync(id);

            if (language == null)
            {
                return NotFound($"No languages found with ID {id}");
            }
            return Ok(language);
        }
        [HttpPost]
        public async Task<IActionResult> AddLanguageAsync(LanguageDTO language)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            // Convertir DTO en entité DAL
            var languageEntity = language.LanguageToDal();

            // Appeler la méthode async du repository
            var isAdded = await _languageRepository.AddLanguageAsync(languageEntity);

            if (isAdded)
            {
                await _languageHub.Clients.All.SendAsync("notifynewlanguage");
                return Ok(language);
            }
            return BadRequest("Registration Error");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLanguage(int id, string name, string level)
        {
            _languageRepository.UpdateLanguage(id, name, level);
            return Ok();
        }
    }
}














//Copyrite https://github.com/POLLESSI
