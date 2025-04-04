//using PortFolioPolLESSIRE0.DTOs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortFolioPolLESSIRE0.DAL.Entities;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace PortFolioPolLESSIRE1.API.Hubs
{
    public class ExperienceHub : Hub
    {
#nullable disable
        private readonly ILogger<ExperienceHub> _logger;

        public ExperienceHub(ILogger<ExperienceHub> logger)
        {
            _logger = logger;
        }

        public async Task RefreshExperience()
        {
            _logger.LogInformation("RefreshExperience called");
            await Clients.All.SendAsync("notifynewexperience");
        }
    }
}