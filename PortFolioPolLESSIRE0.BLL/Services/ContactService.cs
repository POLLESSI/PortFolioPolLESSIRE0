using Microsoft.AspNetCore.SignalR.Client;
using PortFolioPolLESSIRE0.BLL.Interfaces;
using PortFolioPolLESSIRE0.BLL;
using PortFolioPolLESSIRE0.DAL.Repositories;
using PortFolioPolLESSIRE0.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Components;
using PortFolioPolLESSIRE0.DAL.Entities;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PortFolioPolLESSIRE0.BLL.Services
{
    public class ContactService : IContactService
    {
#nullable disable
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public Task<bool> AddContactAsync(Contact contact)
        {
            try
            {
                if (contact == null)
                {
                    throw new System.ArgumentNullException(nameof(contact));
                }
                return _contactRepository.AddContactAsync(contact);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error add Certification: {ex.ToString}");
                return null;
            }
        }

        public void AddContact(Contact contact)
        {
            try
            {
                _contactRepository.AddContact(contact);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Create Contact: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Contact?>> GetAllContactsAsync()
        {
            try
            {
                return await _contactRepository.GetAllContactsAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error return Contacts : {ex.Message}");
                return null;
            }
        }

        public async Task<Contact?> GetByIdContactAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new System.ArgumentException("Id must be greater than 0", nameof(id));
                }
                return await _contactRepository.GetByIdContactAsync(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Contact: {ex.ToString}");
                return null;
            }
        }

        public Contact UpdateContact(int id, string name, string email, string phone)
        {
            try
            {
                var UpdateContact = _contactRepository.UpdateContact(id, name, email, phone);
                return UpdateContact;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating contact : {ex}");
            }
            return new Contact();
        }
    }
}















//Copyrite https://github.com/POLLESSI
