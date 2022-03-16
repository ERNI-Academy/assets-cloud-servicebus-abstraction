﻿using AzureSB = Azure.Messaging.ServiceBus;
using SB.Abstraction.Contract;
using SB.Abstraction.Contract.Client;
using System;
using SB.Abstraction;
using SB.Abstraction.Config;

namespace SB.UsageSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create Listener");
            ISBServiceClient service = new ServiceBusClient(new SBConfig() {  ConnectionString = "Endpoint=sb://sbasset.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+lS3xJGQRsMeucKYHt2SG08VhRGCLZA++CqJm7lhlrQ=" });
            IListener listener = service.GetListener("");
            Console.ReadLine();
        }
    }
}
