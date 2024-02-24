using Azure.Messaging.ServiceBus;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
namespace SendingMessage
{
    public class Program
    {
        static string connectionString = "Endpoint=sb://servicebusdrake.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=4qlVsIN7Y7C2edXLEalqQSNWhLCF+M5Sw7cJiwWw3WE=";
        private static ServiceBusClient _client;
        private static ServiceBusSender _clientSender;
        private
        const string QUEUE_NAME = "webjob1"; // It should be as same as queue name given in the Host creation time
        static async Task Main()
        {
            try
            {
                _client = new ServiceBusClient(connectionString);
                _clientSender = _client.CreateSender(QUEUE_NAME);

                var objMessages = new List<Messages>()
                    {
                        new Messages()
                        {
                          MessageId = 1,
                          Subject = "First Message"
                        },
                        new Messages()
                        {
                         MessageId = 2,
                         Subject = "Second Message"
                        },
                         new Messages()
                        {
                          MessageId = 3,
                          Subject = "Third Message"
                        }
                    };
                foreach (var item in objMessages)
                {
                    string messagePayload = JsonSerializer.Serialize(item);
                    ServiceBusMessage message = new ServiceBusMessage(messagePayload);
                    await _clientSender.SendMessageAsync(message).ConfigureAwait(false);
                }
            }
            catch (System.Exception e)
            {

                throw;
            }

        }
        public class Messages
        {
            public int MessageId
            {
                get;
                set;
            }
            public string Subject
            {
                get;
                set;
            }
        }
    }
}
