# About 
**Service Bus Topic/Subscriptions Abstraction** is a small dll ( on the next iteration, it will be a nuget package) that provides a robust and reusable implementations. 

the main focus of this dll is add the publish and listener features to your owns projects.

## Built With

- [.Net Core 3.1](https://docs.microsoft.com/es-es/dotnet/core/whats-new/dotnet-core-3-1)
- [c# 8](https://docs.microsoft.com/es-es/dotnet/csharp/whats-new/csharp-8)


# Features
- ServiceBusClient abstraction
- Message abstraction
- Listener client
- Publisher client

# Getting Started
At this point, we have to use this project like dll or directly on our production projects.

On next releases, we transform the solution into nuget. 

## Prerequisites

 - [.Net Core 3.1](https://docs.microsoft.com/es-es/dotnet/core/whats-new/dotnet-core-3-1)
- [c# 8](https://docs.microsoft.com/es-es/dotnet/csharp/whats-new/csharp-8)


## Dependencies

- Newtonsoft nuget
- Azure.Messaging.ServiceBus nuget
- .NETStandard 2.0
- System.Text.Json

## Installation
At this point, it is possible to use that asset:
- Cloning the repo and use it directly on you solution. On this way, you will have access too entire code. 
- Using the dll located on Release folder

## Notes

- At this point only can be used with ServiceBus. On next iteration, it'll be implemented a development mode to be used on localhost environments. 

## Object definitions

### ServiceBusClient
```c#
    public interface ISBServiceClient
    {
        IListener GetListener(string topicName = "");
        IPublisher GetPublisher(string topicName = "");
    }
```
### ISBClientConfig client
```c#
    public interface ISBConfig
    {
        public string ConnectionString { get; set; }
        public string Topic { get; set; }
        public string Subscription { get; set; }
    }
```
### Listener client
```c#
    public interface IListener:IClient
    {
        void Run(Action<IMessage> callback);
    }
```
### Publisher client
```c#
    public interface IPublisher:IClient
    {
        void SendAsync(dynamic message);
    }
```
### IMessage 
```c#
    public interface IMessage : IAbstractMessage
    {
        dynamic Value { get; }
    }
```
### IAbstractMessage 
```c#
    public interface IAbstractMessage
    {
        Guid Id { get; }
    }
```
## Samples

### Create ServiceBusClient

The ServiceBusClient is the services that will create the proper clients( listener or publisher).This service use like configuration a own object **SBConfig** that implement **ISBConfig**, so, if you want to change the end implementation of that object you should implement a new one and resolve it on IoC .

```c#
 ISBServiceClient service = new ServiceBusClient(new SBConfig()
            {
                ConnectionString = "Endpoint=sb://sbasset.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+lS3xJGQRsMeucKYHt2SG08VhRGCLZA++CqJm7lhlrQ=",
                Topic = "assetsample",
                Subscription = "assetsubs"
            });
```
* To find the correct connectionstring you should go to azure portal -> ServiceBus account -> Shared access policies and there , choose the **primary key** 

![connectionstring](connectionstring.jpg)

### Create Listener Client
The listener client is an artifact that bring you the capability to be connected on streaming to the concrete subscription.Once you add a callback to this artifact, your software received all messages sent it to the Topic related with the subscription configured.

```c#
    IListener listener = service.GetListener("assetsample");
    listener.Run((message) => { Console.WriteLine(message.ToString()); });
```

In this sample we have created a lambda function, but you can use more traditional mechanism.

Take aware about you will receive an **IMessage** object

### Create Publisher client
The Publisher is an artefact that bring you the capability to send messages to a concrete Topic. 

The object are abtracted into **IMessage** internal model. 

```c#
    IPublisher publisher = service.GetPublisher("assetsample");
    for (int i = 0; i < 20; i++)
    {
        publisher.SendAsync(new { prop1 = i.ToString(), prop2 = "2" }); 
        System.Threading.Thread.Sleep(100);
    }
```
          


# Contributing

Please see our [Contribution Guide](CONTRIBUTING.md) to learn how to contribute.

# License

[MIT](LICENSE) © 2022 [ERNI - Swiss Software Engineering](https://www.betterask.erni)

**Contact:** 

Manu Delgado  - [@mdelgadodiaz83](https://twitter.com/MDelgadoDiaz83) - mdelgadodiaz83@gmail.com