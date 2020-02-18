using ClientLibrary;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleSample.Service
{
    public class TimerService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly Client _client;
        private readonly IConfiguration _config;

        public TimerService(IConfiguration config)
        {
            _config = config;
            var username = _config.GetValue<string>("AppSettings:Username");
            var password = _config.GetValue<string>("AppSettings:Password");

            _client = new Client(username, password);
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now}: Timed Service is starting.");
            _timer = new Timer(DoWorkAsync, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }
        private void DoWorkAsync(object state)
        {
            Console.WriteLine($"{DateTime.Now}: Get LiveScores");
            var scores = _client.GetTennisLiveScores();
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now}: Timed Service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
