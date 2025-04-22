using PortFolioPolLESSIRE0.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortFolioPolLESSIRE0.DAL.Entities.Skill;

namespace PortFolioPolLESSIRE0.BLL.Interfaces
{
    public interface ISkillService
    {
#nullable disable
        Task<IEnumerable<Skill?>> GetAllSkillsAsync();
        Task<bool> AddSkillAsync(Skill skill);
        void AddSkill(Skill skill);
        Task<Skill?> GetByIdSkillAsync(int id);
        Skill? UpdateSkill(int id, string name, string level, string description);
    }
}

























//Copyrite https://github.com/POLLESSI