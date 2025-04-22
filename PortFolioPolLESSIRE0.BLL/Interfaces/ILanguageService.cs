using PortFolioPolLESSIRE0.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortFolioPolLESSIRE0.DAL.Entities.Language;

namespace PortFolioPolLESSIRE0.BLL.Interfaces
{
    public interface ILanguageService
    {
#nullable disable
        Task<IEnumerable<Language?>> GetAllLanguagesAsync();
        Task<bool>   AddLanguageAsync(Language language);
        void AddLanguage(Language language);
        Task<Language?> GetByIdLanguageAsync(int id);
        Language? UpdateLanguage(int id, string name, string level);
    }
}



















//Copyrite https://github.com/POLLESSI