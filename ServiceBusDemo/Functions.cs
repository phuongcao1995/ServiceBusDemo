using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ServiceBusDemo
{
    public class Functions
    {
        public static void processservicebus([ServiceBusTrigger("webjob1", Connection = "AzureWebJobsServiceBus")] string myQueueItem, ILogger log)
        {
            Console.WriteLine(myQueueItem.ToString());
            Console.ReadLine();


        }
    }
}
