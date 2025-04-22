//using PortFolioPolLESSIRE0.DTOs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortFolioPolLESSIRE0.DAL.Entities;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace PortFolioPolLESSIRE1.API.Hubs
{
    public class InterestHub : Hub
    {
#nullable disable
        private readonly ILogger<InterestHub> _logger;

        public InterestHub(ILogger<InterestHub> logger)
        {
            _logger = logger;
        }

        public async Task RefreshInterest()
        {
            _logger.LogInformation("RefreshInterest called");
            await Clients.All.SendAsync("notifynewinterest");
        }
    }
}














//Copyrite https://github.com/POLLESSI