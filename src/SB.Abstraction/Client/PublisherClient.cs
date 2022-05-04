using Azure.Messaging.ServiceBus;
using SB.Abstraction.Contract.Client;
using AzureSB = Azure.Messaging.ServiceBus;
using System.Text.Json;
using SB.Abstraction.Contract.Models;

namespace SB.Abstraction
{
    public class PublisherClient : IPublisher
    {
        public AzureSB.ServiceBusClient client { get; set; }
        private AzureSB.ServiceBusSender sender;
        private string topic;
        private string subs;
        public PublisherClient(AzureSB.ServiceBusClient client, string nameTopic, string nameSubscription)
        {
            this.client = client;
            topic = nameTopic;
            subs = nameSubscription;
            LoadSender();
        }
        private void LoadSender()
        {
            sender = client.CreateSender(topic);
        }
        public async void SendAsync(IMessage message)
        {
            string jsonMessage = JsonSerializer.Serialize(message);
            await sender.SendMessageAsync(new ServiceBusMessage(jsonMessage));
        }
    }
}
