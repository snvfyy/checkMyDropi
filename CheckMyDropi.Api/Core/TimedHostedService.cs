using CheckMyDropi.Api.Data.Context;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;


namespace CheckMyDropi.Api.Core
{
    internal class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        //private readonly DroppyContext _context;
        private Timer _timer;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
            //_context = context;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting.");

            _timer = new System.Threading.Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(30));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
           // _logger.LogInformation("Timed Background Service is working.");

            //try
            //{
            //    var webRequest = WebRequest.Create(@"http://127.0.0.1/api/update");
            //    string strContent = null;
            //    using (var response = webRequest.GetResponse())
            //    using (var content = response.GetResponseStream())
            //    using (var reader = new StreamReader(content))
            //    {
            //        strContent = reader.ReadToEnd();
            //    }
            //    Console.WriteLine(strContent);

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.StackTrace);
            //}
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
