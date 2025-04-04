using PortFolioPolLESSIRE0.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortFolioPolLESSIRE0.DAL.Entities.Experience;

namespace PortFolioPolLESSIRE0.BLL.Interfaces
{
    public interface IExperienceService
    {
    #nullable disable
        Task<IEnumerable<Experience?>> GetAllExperiencesAsync();
        Task<bool> AddExperienceAsync(Experience experience);
        void AddExperience(Experience experience);
        Task<Experience?> GetByIdExperienceAsync(int id);
    }
}
