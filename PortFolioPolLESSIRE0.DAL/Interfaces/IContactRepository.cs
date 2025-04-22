using PortFolioPolLESSIRE0.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortFolioPolLESSIRE0.DAL.Entities.Contact;

namespace PortFolioPolLESSIRE0.DAL.Interfaces
{
    public interface IContactRepository
    {
    #nullable disable
        Task<IEnumerable<Contact?>> GetAllContactsAsync(bool includeInactive = false);
        Task<bool> AddContactAsync(Contact contact);
        void AddContact(Contact contact);
        Task<Contact?> GetByIdContactAsync(int id);
        Contact? UpdateContact(int id, string name, string email, string phone);
    }
}


















//Copyrite https://github.com/POLLESSI