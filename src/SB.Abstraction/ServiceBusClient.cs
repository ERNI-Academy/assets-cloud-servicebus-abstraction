using SB.Abstraction.Config;
using SB.Abstraction.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using AzureSB = Azure.Messaging.ServiceBus;

namespace SB.Abstraction
{
    public class ServiceBusClient:ISBServiceClient
    {
        private AzureSB.ServiceBusClient client;
        private AzureSB.ServiceBusSender sender;
        private AzureSB.ServiceBusReceiver listener;
        private ISBConfig config;
        public ServiceBusClient(ISBConfig options)
        {
            config = options;
            LoadConfig();
        }
        #region Internal methods
        private bool IsServiceBusAccountRunning()
        {
            return client != null || (client != null && !client.IsClosed);
        }
        private void LoadConfig()
        {
            if (!IsServiceBusAccountRunning()) client = new AzureSB.ServiceBusClient(config.ConnectionString);

        }
        #endregion
        public object GetListener()
        {
            throw new NotImplementedException();
        }

        public object GetPublisher(string topicName= "")
        {
            string properTopicName = topicName ?? config.Topic;
            sender = client.CreateSender();
        }

    }
}
