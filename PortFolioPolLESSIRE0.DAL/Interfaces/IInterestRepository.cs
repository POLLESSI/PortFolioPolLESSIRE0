using PortFolioPolLESSIRE0.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortFolioPolLESSIRE0.DAL.Entities.Interest;

namespace PortFolioPolLESSIRE0.DAL.Interfaces
{
    public interface IInterestRepository
    {
    #nullable disable
        Task<IEnumerable<Interest?>> GetAllInterestsAsync(bool includeInactive = false);
        Task<bool> AddInterestAsync(Interest interest);
        void AddInterest(Interest interest);
        Task<Interest?> GetByIdInterestAsync(int id);
        Interest? UpdateInterest(int id, string name, string description);
    }
}

















//Copyrite https://github.com/POLLESSI