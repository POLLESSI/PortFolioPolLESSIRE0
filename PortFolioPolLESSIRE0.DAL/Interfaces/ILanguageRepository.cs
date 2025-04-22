using PortFolioPolLESSIRE0.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortFolioPolLESSIRE0.DAL.Entities.Language;

namespace PortFolioPolLESSIRE0.DAL.Interfaces
{
    public interface ILanguageRepository
    {
    #nullable disable
        Task<IEnumerable<Language?>> GetAllLanguagesAsync(bool includeInactive = false);
        Task<bool> AddLanguageAsync(Language language);
        void AddLanguage(Language language);
        Task<Language?> GetByIdLanguageAsync(int id);
        Language? UpdateLanguage(int id, string name, string level);
    }
}






















//Copyrite https://github.com/POLLESSI