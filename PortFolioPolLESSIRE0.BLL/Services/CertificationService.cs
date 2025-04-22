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
    public class CertificationService : ICertificationService
    {
#nullable disable
        private readonly ICertificationRepository _certificationRepository;

        public CertificationService(ICertificationRepository certificationRepository)
        {
            _certificationRepository = certificationRepository;
        }

        public async Task<bool> AddCertificationAsync(Certification certification)
        {
            try
            {
                if (certification == null)
                {
                    throw new System.ArgumentNullException(nameof(certification));
                }
                return await _certificationRepository.AddCertificationAsync(certification);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error add Certification: {ex.ToString}");
                return false;
            }
        }

        public void AddCertification(Certification certification)
        {
            try
            {
                _certificationRepository.AddCertification(certification);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Create Certification: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Certification?>> GetAllCertificationsAsync()
        {
            try
            {
                return await _certificationRepository.GetAllCertificationsAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error return Certifications : {ex.Message}");
                return null;
            }
        }

        public async Task<Certification?> GetByIdCertificationAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new System.ArgumentException("Id must be greater than 0", nameof(id));
                }
                return await _certificationRepository.GetByIdCertificationAsync(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Certification: {ex.ToString}");
                return null;
            }
        }

        public Certification UpdateCertification(int id, string name, string authority, string licenceNumber, string url, DateTime licenceDate)
        {
            try
            {
                var UpdateCertification = _certificationRepository.UpdateCertification(id, name, authority, licenceNumber, url, licenceDate);
                return UpdateCertification;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating certification : {ex}");
            }
            return new Certification();
        }
    }
}





















//Copyrite https://github.com/POLLESSI
