using PortFolioPolLESSIRE0.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortFolioPolLESSIRE0.DAL.Entities.Project;

namespace PortFolioPolLESSIRE0.BLL.Interfaces
{
    public interface IProjectService
    {
#nullable disable
        Task<IEnumerable<Project?>> GetAllProjectsAsync();
        Task<bool> AddProjectAsync(Project project);
        void AddProject(Project project);
        Task<Project?> GetByIdProjectAsync(int id);
    }
}
