using System;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
namespace ServiceBusDemo
{
    class Program
    {
        static async Task Main()
        {
            var hostBuilder = new HostBuilder();
            hostBuilder.ConfigureWebJobs((context, builder) => {
                builder.AddServiceBus(options => options.MaxConcurrentCalls = 1);
            });
            var host = hostBuilder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
