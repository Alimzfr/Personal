using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alimzfr.ServiceLayer.Jobs
{
    public class BackroundJobs : BackgroundService
    {
        private readonly ILogger<BackroundJobs> _logger;
        public BackroundJobs(ILogger<BackroundJobs> logger)
        {
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Start backgroundJobs!");
        }
    }
}
