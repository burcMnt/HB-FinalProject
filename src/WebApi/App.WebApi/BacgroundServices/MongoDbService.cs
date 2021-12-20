using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Application.WebApi.BacgroundServices
{
    /*public class MongoDbService2 : BackgroundService
    {
        //private HttpClient client;
        //public override Task StartAsync(CancellationToken cancellationToken)
        //{
        //    client = new HttpClient();

        //    return base.StartAsync(cancellationToken);
        //}
        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        var result = await client.GetAsync("https://www.google.com");
        //        if (result.IsSuccessStatusCode)
        //        {

        //        }
        //        await Task.Delay(5000, stoppingToken);
        //    }
        //}
    }*/

    public class MongoDbService : IHostedService,IDisposable
    {
        private Timer timer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(MongoDbService)} started...");

           // timer = new Timer(writeDataOnMongoDb, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;

            //while (!cancellationToken.IsCancellationRequested)
            //{
            //    writeDataOnMongoDb();
            //    await Task.Delay(1000);
            //}
        }
        private void writeDataOnMongoDb(object state)
        {
            Console.WriteLine($"DateTime is {DateTime.Now.ToLongTimeString()}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //timer?.Change(Timeout.Infinite, 0);
            Console.WriteLine($"{nameof(MongoDbService)} stopped...");

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer = null;
        }
    }
}
