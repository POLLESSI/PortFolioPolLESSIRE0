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
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PortFolioPolLESSIRE0.BLL.Services
{
    public class EducationService : IEducationService
    {
    #nullable disable
        private readonly IEducationRepository _educationRepository;

        public EducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public Task<bool> AddEducationAsync(Education education)
        {
            try
            {
                return _educationRepository.AddEducationAsync(education);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error add Education: {ex.ToString}");
                return null;
            }
        }

        public void AddEducation(Education education)
        {
            try
            {
                _educationRepository.AddEducation(education);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Create Education: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Education?>> GetAllEducationsAsync()
        {
            try
            {
                return await _educationRepository.GetAllEducationsAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error return Educations : {ex.Message}");
                return null;
            }
        }

        public async Task<Education?> GetByIdEducationAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new System.ArgumentException("Id must be greater than 0", nameof(id));
                }
                return await _educationRepository.GetByIdEducationAsync(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Education: {ex.ToString}");
                return null;
            }
        }

        public Education UpdateEducation(int id, string school, string degree, DateTime startDate, DateTime endDate, string description)
        {
            try
            {
                var UpdateEducation = _educationRepository.UpdateEducation(id, school, degree, startDate, endDate, description);
                return UpdateEducation;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating education : {ex}");
            }
            return new Education();
        }
    }
}















//Copyrite https://github.com/POLLESSI
