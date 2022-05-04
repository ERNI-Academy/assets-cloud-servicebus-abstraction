using SB.Abstraction.Client;
using SB.Abstraction.Config;
using SB.Abstraction.Contract;
using SB.Abstraction.Contract.Client;
using AzureSB = Azure.Messaging.ServiceBus;

namespace SB.Abstraction
{
    public class ServiceBusClient : ISBServiceClient
    {
        private readonly AzureSB.ServiceBusClient client;
        private const string PUBLISHER = "pub";
        private const string LISTENER = "lis";
        private readonly ISBConfig config;
        public ServiceBusClient(ISBConfig options)
        {
            config = options;
            client = new AzureSB.ServiceBusClient(config.ConnectionString);
        }

        #region Internal methods
        private IClient CreateClients(dynamic option)
        {
            IClient busClient;
            if (option._type == PUBLISHER) busClient = new PublisherClient(client, option._nameQueue, config.Subscription);
            else busClient = new ListenerClient(client, option._nameQueue, config.Subscription);
            return busClient;
        }
        #endregion

        public IListener GetListener(string topicName = "")
        {
            string properTopicName = topicName ?? config.Topic;
            IListener listener = (IListener)CreateClients(new { _type = LISTENER, _client = client, _nameQueue = properTopicName, _nameSubs = config.Subscription });
            return listener;
        }

        public IPublisher GetPublisher(string topicName = "")
        {
            string properTopicName = topicName ?? config.Topic;
            IPublisher sender = (IPublisher)CreateClients(new { _type = PUBLISHER, _client = client, _nameQueue = properTopicName });
            return sender;
        }
    }

}
