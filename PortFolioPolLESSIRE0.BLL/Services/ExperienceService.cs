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
    public class ExperienceService : IExperienceService
    {
    #nullable disable
        private readonly IExperienceRepository _experienceRepository;

        public ExperienceService(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public Task<bool> AddExperienceAsync(Experience experience)
        {
            try
            {
                return _experienceRepository.AddExperienceAsync(experience);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error add Experience: {ex.ToString}");
                return null;
            }
        }

        public void AddExperience(Experience experience)
        {
            try
            {
                _experienceRepository.AddExperience(experience);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Create Experience: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Experience?>> GetAllExperiencesAsync()
        {
            try
            {
                return await _experienceRepository.GetAllExperiencesAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error return Experiences : {ex.Message}");
                return null;
            }
        }

        public async Task<Experience?> GetByIdExperienceAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new System.ArgumentException("Id must be greater than 0", nameof(id));
                }
                return await _experienceRepository.GetByIdExperienceAsync(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Experience: {ex.ToString}");
                return null;
            }
        }
    }
}
