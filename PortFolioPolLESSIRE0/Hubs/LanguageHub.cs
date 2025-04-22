//using PortFolioPolLESSIRE0.DTOs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortFolioPolLESSIRE0.DAL.Entities;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace PortFolioPolLESSIRE1.API.Hubs
{
    public class LanguageHub : Hub
    {
#nullable disable
        private readonly ILogger<LanguageHub> _logger;

        public LanguageHub(ILogger<LanguageHub> logger)
        {
            _logger = logger;
        }

        public async Task RefreshLanguage()
        {
            _logger.LogInformation("RefreshLanguage called");
            await Clients.All.SendAsync("notifynewlanguage");
        }
    }
}
















//Copyrite https://github.com/POLLESSI