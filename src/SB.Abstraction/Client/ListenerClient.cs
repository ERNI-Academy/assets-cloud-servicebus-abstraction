using SB.Abstraction.Contract.Client;
using SB.Abstraction.Contract.Models;
using SB.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AzureSB = Azure.Messaging.ServiceBus;

namespace SB.Abstraction.Client
{
    public class ListenerClient : IListener
    {
        private AzureSB.ServiceBusClient client;
        static AzureSB.ServiceBusProcessor processor;
        private Action<IMessage> callback;
        private string queue;
        private string subs;

        public ListenerClient(AzureSB.ServiceBusClient client, string nameTopic, string nameSubscription)
        {
            this.client = client;
            this.queue = nameTopic;
            subs = nameSubscription;
            LoadProcessor();
        }
        private void LoadProcessor()
        {
            processor = client.CreateProcessor(queue, subs, new AzureSB.ServiceBusProcessorOptions());
            processor.ProcessMessageAsync += MessageHandler;
            processor.ProcessErrorAsync += ErrorHandler;
        }
        private async Task MessageHandler(AzureSB.ProcessMessageEventArgs args)
        {

            string body = args.Message.Body.ToString();
            var z = JsonSerializer.Serialize(body);
            IMessage message = new SBMessage() { Key = new Guid(args.Message.MessageId), Value = z };

            callback(message);
        }
        private Task ErrorHandler(AzureSB.ProcessErrorEventArgs args)
        {
            return Task.CompletedTask;
        }
        public async void Run(Action<IMessage> callback)
        {
            this.callback = callback;
            await processor.StartProcessingAsync();
        }
    }
}
