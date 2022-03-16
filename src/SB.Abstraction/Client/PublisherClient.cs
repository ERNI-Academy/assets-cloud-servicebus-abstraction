using Azure.Messaging.ServiceBus;
using SB.Abstraction.Contract.Client;
using AzureSB = Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SB.Abstraction
{
    public class PublisherClient : IPublisher
    {
        public AzureSB.ServiceBusClient client { get; set; }
        private AzureSB.ServiceBusSender sender;
        private string queue;
        public PublisherClient(AzureSB.ServiceBusClient client,string nameQueue= "")
        {
            this.client= client;
            queue = nameQueue;
            LoadSender();

        }
        private void LoadSender()
        {
            sender = client.CreateSender(queue);

        }
        public async void SendAsync(dynamic message)
        {
            
            string jsonMessage = JsonSerializer.Serialize(message);
            await sender.SendMessageAsync(new ServiceBusMessage(jsonMessage));
            
        }
    }
}
