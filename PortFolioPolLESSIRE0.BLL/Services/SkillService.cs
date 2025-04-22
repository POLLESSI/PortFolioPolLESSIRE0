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
    public class SkillService : ISkillService
    {
    #nullable disable
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public Task<bool> AddSkillAsync(Skill skill)
        {
            try
            {
                return _skillRepository.AddSkillAsync(skill);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error add project: {ex.ToString}");
                return null;
            }
        }

        public void AddSkill(Skill skill)
        {
            try
            {
                _skillRepository.AddSkill(skill);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Create Skill: {ex.ToString}");
            }
        }

        public async Task<IEnumerable<Skill?>> GetAllSkillsAsync()
        {
            try
            {
                return await _skillRepository.GetAllSkillAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error return Skills : {ex.Message}");
                return null;
            }
        }

        public async Task<Skill?> GetByIdSkillAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new System.ArgumentException("Id must be greater than 0", nameof(id));
                }
                return await _skillRepository.GetByIdSkillAsync(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Skill: {ex.ToString}");
                return null;
            }
        }

        public Skill UpdateSkill(int id, string name, string level, string description)
        {
            try
            {
                var UpdateSkill = _skillRepository.UpdateSkill(id, name, level, description);
                return UpdateSkill;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating skill : {ex}");
            }
            return new Skill();
        }
    }
}














//Copyrite https://github.com/POLLESSI
