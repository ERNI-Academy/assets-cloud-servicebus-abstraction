using AzureSB = Azure.Messaging.ServiceBus;
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
            ISBServiceClient service = new ServiceBusClient(new SBConfig()
            {
                ConnectionString = "Endpoint=sb://sbasset.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+lS3xJGQRsMeucKYHt2SG08VhRGCLZA++CqJm7lhlrQ=",
                Topic = "assetsample",
                Subscription = "assetsubs"
            });

            ///Create a listener
            IListener listener = service.GetListener("assetsample");
            listener.Run((message) => { Console.WriteLine(message.ToString()); });


            //create publisher
            IPublisher publisher = service.GetPublisher("assetsample");
            for (int i = 0; i < 20; i++)
            {
                publisher.SendAsync(new { prop1 = i.ToString(), prop2 = "2" }); ;

                System.Threading.Thread.Sleep(100);
            }
            Console.ReadLine();
        }
    }
}
