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
    public class InterestService : IInterestService
    {
#nullable disable
        private readonly IInterestRepository _interestRepository;

        public InterestService(IInterestRepository interestRepository)
        {
            _interestRepository = interestRepository;
        }

        public Task<bool> AddInterestAsync(Interest interest)
        {
            try
            {
                return _interestRepository.AddInterestAsync(interest);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error add Interest: {ex.ToString}");
                return null;
            }
        }

        public void AddInterest(Interest interest)
        {
            try
            {
                _interestRepository.AddInterest(interest);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Create Interest: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Interest?>> GetAllInterestsAsync()
        {
            try
            {
                return await _interestRepository.GetAllInterestsAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error return Interests : {ex.Message}");
                return null;
            }
        }

        public async Task<Interest?> GetByIdInterestAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new System.ArgumentException("Id must be greater than 0", nameof(id));
                }
                return await _interestRepository.GetByIdInterestAsync(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Interest: {ex.ToString}");
                return null;
            }
        }
    }
}
