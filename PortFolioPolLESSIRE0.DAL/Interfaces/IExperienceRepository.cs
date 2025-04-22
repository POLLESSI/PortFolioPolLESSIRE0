using PortFolioPolLESSIRE0.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortFolioPolLESSIRE0.DAL.Entities.Experience;

namespace PortFolioPolLESSIRE0.DAL.Interfaces
{
    public interface IExperienceRepository
    {
    #nullable disable
        Task<IEnumerable<Experience?>> GetAllExperiencesAsync(bool includeInactive = false);
        Task<bool> AddExperienceAsync(Experience experience);
        void AddExperience(Experience experience);
        Task<Experience?> GetByIdExperienceAsync(int id);
        Experience? UpdateExperience(int id, string company, string position, string description, DateTime startDate, DateTime endDate);
    }
}

















//Copyrite https://github.com/POLLESSI