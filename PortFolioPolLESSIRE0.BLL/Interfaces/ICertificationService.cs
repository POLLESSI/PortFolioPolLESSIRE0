using PortFolioPolLESSIRE0.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortFolioPolLESSIRE0.DAL.Entities.Certification;

namespace PortFolioPolLESSIRE0.BLL.Interfaces
{
    #nullable disable
    public interface ICertificationService
    {
        Task<IEnumerable<Certification?>> GetAllCertificationsAsync();
        void AddCertification(Certification certification);
        Task<bool> AddCertificationAsync(Certification certification);
        Task<Certification?> GetByIdCertificationAsync(int id);
    }
}
