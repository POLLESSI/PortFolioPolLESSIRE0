using PortFolioPolLESSIRE0.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortFolioPolLESSIRE0.DAL.Entities.Project;

namespace PortFolioPolLESSIRE0.DAL.Interfaces
{
    public interface IProjectRepository
    {
    #nullable disable
        Task<IEnumerable<Project?>> GetAllProjectAsync(bool includeInactive = false);
        Task<bool> AddProjectAsync(Project project);
        void AddProject(Project project);
        Task<Project?> GetByIdProjectAsync(int id);
        Project? UpdateProject(int id, string name, string description, string url, DateTime startDate, DateTime endDate);
    }
}




















//Copyrite https://github.com/POLLESSI
