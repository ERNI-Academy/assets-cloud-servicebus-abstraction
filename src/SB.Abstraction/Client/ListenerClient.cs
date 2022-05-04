using SB.Abstraction.Contract.Client;
using SB.Abstraction.Contract.Models;
using SB.Abstraction.Model;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using AzureSB = Azure.Messaging.ServiceBus;

namespace SB.Abstraction.Client
{
    public class ListenerClient : IListener
    {
        private readonly AzureSB.ServiceBusClient client;
        private AzureSB.ServiceBusProcessor processor;
        private Action<IMessage> callback;
        private readonly string queue;
        private readonly string subs;

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
        private Task MessageHandler(AzureSB.ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            var serialized = JsonSerializer.Serialize(body);
            IMessage message = new SBMessage() { Key = new Guid(args.Message.MessageId), Value = serialized };

            callback(message);

            return Task.CompletedTask;
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
