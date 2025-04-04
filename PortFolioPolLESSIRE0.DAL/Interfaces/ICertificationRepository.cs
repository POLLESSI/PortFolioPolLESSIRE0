using PortFolioPolLESSIRE0.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortFolioPolLESSIRE0.DAL.Entities.Certification;

namespace PortFolioPolLESSIRE0.DAL.Interfaces
{
    public interface ICertificationRepository
    {
    #nullable disable
        Task<IEnumerable<Certification?>> GetAllCertificationsAsync(bool includeInactive = false);
        Task<bool> AddCertificationAsync(Certification certification);
        void AddCertification(Certification certification);
        Task<Certification?> GetByIdCertificationAsync(int id);
    }
}

