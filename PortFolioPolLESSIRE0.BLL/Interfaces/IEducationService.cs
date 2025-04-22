using PortFolioPolLESSIRE0.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortFolioPolLESSIRE0.DAL.Entities.Education;

namespace PortFolioPolLESSIRE0.BLL.Interfaces
{
    public interface IEducationService
    {
    #nullable disable
        Task<IEnumerable<Education?>> GetAllEducationsAsync();
        Task<bool> AddEducationAsync(Education education);
        void AddEducation(Education education);
        Task<Education?> GetByIdEducationAsync(int id);
        Education? UpdateEducation(int id, string school, string degree, DateTime startDate, DateTime endDate, string description);
    }
}
















//Copyrite https://github.com/POLLESSI