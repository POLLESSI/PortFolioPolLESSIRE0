using PortFolioPolLESSIRE0.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortFolioPolLESSIRE0.DAL.Entities.Interest;

namespace PortFolioPolLESSIRE0.BLL.Interfaces
{
    public interface IInterestService
    {
#nullable disable
        Task<IEnumerable<Interest?>> GetAllInterestsAsync();
        Task<bool> AddInterestAsync(Interest interest);
        void AddInterest(Interest interest);
        Task<Interest?> GetByIdInterestAsync(int id);
        Interest? UpdateInterest(int id, string name, string description);
    }
}



















//Copyrite https://github.com/POLLESSI
