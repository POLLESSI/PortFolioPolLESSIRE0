using Microsoft.AspNetCore.SignalR.Client;
using PortFolioPolLESSIRE0.BLL.Interfaces;
using PortFolioPolLESSIRE0.BLL;
using PortFolioPolLESSIRE0.DAL.Repositories;
using PortFolioPolLESSIRE0.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Components;
using PortFolioPolLESSIRE0.DAL.Entities;

namespace PortFolioPolLESSIRE0.BLL.Services
{
    public class LanguageService : ILanguageService
    {
#nullable disable
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public Task<bool> AddLanguageAsync(Language language)
        {
            try
            {
                
                return _languageRepository.AddLanguageAsync(language);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error add Language: {ex.ToString}");
                return null;
            }
        }

        public void AddLanguage(Language language)
        {
            try
            {
                _languageRepository.AddLanguage(language);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Create Language: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Language?>> GetAllLanguagesAsync()
        {
            try
            {
                return await _languageRepository.GetAllLanguagesAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error return Languages : {ex.Message}");
                return null;
            }
        }

        public async Task<Language?> GetByIdLanguageAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new System.ArgumentException("Id must be greater than 0", nameof(id));
                }
                return await _languageRepository.GetByIdLanguageAsync(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Language: {ex.ToString}");
                return null;
            }
        }
    }
}
