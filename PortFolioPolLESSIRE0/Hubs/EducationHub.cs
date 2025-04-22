//using PortFolioPolLESSIRE0.DTOs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortFolioPolLESSIRE0.DAL.Entities;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace PortFolioPolLESSIRE1.API.Hubs
{
    public class EducationHub : Hub
    {
#nullable disable
        private readonly ILogger<EducationHub> _logger;

        public EducationHub(ILogger<EducationHub> logger)
        {
            _logger = logger;
        }

        public async Task RefreshEducation()
        {
            _logger.LogInformation("RefreshEducation called");
            await Clients.All.SendAsync("notifyneweducation");
        }
    }
}




















//Copyrite https://github.com/POLLESSI