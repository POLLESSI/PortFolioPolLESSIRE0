//using PortFolioPolLESSIRE0.DTOs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortFolioPolLESSIRE0.DAL.Entities;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace PortFolioPolLESSIRE1.API.Hubs
{
    public class ContactHub : Hub
    {
#nullable disable
        private readonly ILogger<ContactHub> _logger;

        public ContactHub(ILogger<ContactHub> logger)
        {
            _logger = logger;
        }

        public async Task RefreshContact()
        {
            _logger.LogInformation("RefreshContact called");
            await Clients.All.SendAsync("notifynewcontact");
        }
    }
}

















//Copyrite https://github.com/POLLESSI