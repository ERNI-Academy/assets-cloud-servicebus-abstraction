using SB.Abstraction.Contract.Client;
using System;
using System.Collections.Generic;
using System.Text;
using AzureSB = Azure.Messaging.ServiceBus;

namespace SB.Abstraction.Client
{
    public class ListenerClient : IListener
    {
        private AzureSB.ServiceBusClient client;
        private string queue;

        public ListenerClient(AzureSB.ServiceBusClient client, string nameQueue="")
        {
            this.client = client;
            this.queue = nameQueue;
           
        }

        public void OnDataRecived()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
