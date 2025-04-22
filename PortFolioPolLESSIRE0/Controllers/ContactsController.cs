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
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IHubContext<ContactHub> _contactHub;

        public ContactsController(IContactRepository contactRepository, IHubContext<ContactHub> contactHub)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
            _contactHub = contactHub ?? throw new ArgumentNullException(nameof(contactHub));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var contacts = await _contactRepository.GetAllContactsAsync();
            return Ok(contacts);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetByIdContactAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("The contact ID must be a positive integer");
            }
            var contact = await _contactRepository.GetByIdContactAsync(id);
            return Ok(contact);
        }
        [HttpPost]
        public async Task<IActionResult> AddContactAsync(ContactDTO contact)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            // Convertir DTO en entité DAL
            var contactEntity = contact.ContactToDal();

            // Appeler la méthode async du repository
            var isAdded = await _contactRepository.AddContactAsync(contactEntity);

            if (isAdded)
            {
                await _contactHub.Clients.All.SendAsync("notifynewcontact");
                return Ok(contact);
            }

            return BadRequest("Registration error");

        }
        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, string name, string email, string phone)
        {
            _contactRepository.UpdateContact(id, name, email, phone);
            return Ok();
        }
    }
}




















//Copyrite https://github.com/POLLESSI