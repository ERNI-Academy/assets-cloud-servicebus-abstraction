using SB.Abstraction.Contract;
using SB.Abstraction.Contract.Client;
using System;
using SB.Abstraction;
using SB.Abstraction.Config;
using SB.Abstraction.Model;

namespace SB.UsageSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create Listener");
            ISBServiceClient service = new ServiceBusClient(new SBConfig()
            {
                ConnectionString = "[your service bus connection string]",
                Topic = "[your service bus topic name]",
                Subscription = "[your service bus subscription name]"
            });

            ///Create a listener
            IListener listener = service.GetListener("assetsample");
            listener.Run((message) => { Console.WriteLine(message.ToString()); });


            //create publisher
            IPublisher publisher = service.GetPublisher("assetsample");
            for (int i = 0; i < 20; i++)
            {
                publisher.SendAsync(new SBMessage() { Key= Guid.NewGuid(), Value = "35" }); ;

                System.Threading.Thread.Sleep(100);
            }
            Console.ReadLine();
        }
    }
}
