using PortFolioPolLESSIRE0.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortFolioPolLESSIRE0.DAL.Entities.Contact;

namespace PortFolioPolLESSIRE0.BLL.Interfaces
{
    public interface IContactService
    {
    #nullable disable
        Task<IEnumerable<Contact?>> GetAllContactsAsync();
        Task<bool> AddContactAsync(Contact contact);
        void AddContact(Contact contact);
        Task<Contact?> GetByIdContactAsync(int id);
    }
}