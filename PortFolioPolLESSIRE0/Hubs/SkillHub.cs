//using PortFolioPolLESSIRE0.DTOs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortFolioPolLESSIRE0.DAL.Entities;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace PortFolioPolLESSIRE1.API.Hubs
{
    public class SkillHub : Hub
    {
#nullable disable
        private readonly ILogger<SkillHub> _logger;

        public SkillHub(ILogger<SkillHub> logger)
        {
            _logger = logger;
        }

        public async Task RefreshSkill()
        {
            _logger.LogInformation("RefreshSkill called");
            await Clients.All.SendAsync("notifynewskill");
        }
    }
}















//Copyrite https://github.com/POLLESSI