//using PortFolioPolLESSIRE0.DTOs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortFolioPolLESSIRE0.DAL.Entities;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace PortFolioPolLESSIRE1.API.Hubs
{
    public class CertificationHub : Hub
    {
#nullable disable

        private readonly ILogger<CertificationHub> _logger;

        public CertificationHub(ILogger<CertificationHub> logger)
        {
            _logger = logger;
        }

        public async Task RefreshCertification()
        {
            _logger.LogInformation("RefreshCertification called");
            await Clients.All.SendAsync("notifynewcertification");
        }
    }
}













//Copyrite https://github.com/POLLESSI
