﻿using SB.Abstraction.Client;
using SB.Abstraction.Config;
using SB.Abstraction.Contract;
using SB.Abstraction.Contract.Client;
using System;
using System.Collections.Generic;
using System.Text;
using AzureSB = Azure.Messaging.ServiceBus;

namespace SB.Abstraction
{
    public class ServiceBusClient : ISBServiceClient
    {
        private AzureSB.ServiceBusClient client;
        private AzureSB.ServiceBusSender sender;
        private AzureSB.ServiceBusReceiver listener;
        private const string PUBLISHER = "pub";
        private const string LISTENER = "lis";
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
        private IClient CreateClients(dynamic option)
        {
            IClient busClient;
            if (option._type == PUBLISHER) busClient = new PublisherClient(client);
            else busClient = new ListenerClient(client);
            return busClient;
        }
        #endregion
        public IListener GetListener(string topicName = "")
        {
            string properTopicName = topicName ?? config.Topic;
            IListener listener = (IListener)CreateClients(new { _type = LISTENER, _client = client, _nameQueue = properTopicName });
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
