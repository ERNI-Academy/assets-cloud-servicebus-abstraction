# About

**Service Bus Topic/Subscriptions Abstraction** is a small dll ( on the next iteration, it will be a nuget package) that provides a robust and reusable implementations.

the main focus of this dll is add the publish and listener features to your owns projects.

<!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
[![All Contributors](https://img.shields.io/badge/all_contributors-1-orange.svg?style=flat-square)](#contributors)
<!-- ALL-CONTRIBUTORS-BADGE:END -->

## Built With

- [.Net Core 3.1](https://docs.microsoft.com/es-es/dotnet/core/whats-new/dotnet-core-3-1)
- [c# 8](https://docs.microsoft.com/es-es/dotnet/csharp/whats-new/csharp-8)

## Features

- ServiceBusClient abstraction
- Message abstraction
- Listener client
- Publisher client

## Getting Started

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

```sh
git clone https://github.com/ERNI-Academy/assets-cloud-servicebus-abstraction.git
```

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

- To find the correct connectionstring you should go to azure portal -> ServiceBus account -> Shared access policies and there , choose the **primary key**

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

## Contributing

Please see our [Contribution Guide](CONTRIBUTING.md) to learn how to contribute.

## License

![MIT](https://img.shields.io/badge/License-MIT-blue.svg)

(LICENSE) © 2022 [ERNI - Swiss Software Engineering](https://www.betterask.erni)

## Code of conduct

Please see our [Code of Conduct](CODE_OF_CONDUCT.md)

## Stats
![https://repobeats.axiom.co/api/embed/40ef16dfb701ec4dad65007c5888910f45265d44.svg](https://repobeats.axiom.co/api/embed/40ef16dfb701ec4dad65007c5888910f45265d44.svg)

## Follow us

[![Twitter Follow](https://img.shields.io/twitter/follow/ERNI?style=social)](https://www.twitter.com/ERNI)
[![Twitch Status](https://img.shields.io/twitch/status/erni_academy?label=Twitch%20Erni%20Academy&style=social)](https://www.twitch.tv/erni_academy)
[![YouTube Channel Views](https://img.shields.io/youtube/channel/views/UCkdDcxjml85-Ydn7Dc577WQ?label=Youtube%20Erni%20Academy&style=social)](https://www.youtube.com/channel/UCkdDcxjml85-Ydn7Dc577WQ)
[![Linkedin](https://img.shields.io/badge/linkedin-31k-green?style=social&logo=Linkedin)](https://www.linkedin.com/company/erni)

## Contact

📧 [esp-services@betterask.erni](mailto:esp-services@betterask.erni)

Manu Delgado  - [@mdelgadodiaz83](https://twitter.com/MDelgadoDiaz83) - mdelgadodiaz83@gmail.com

## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="https://github.com/mdelgadodiaz83-erni"><img src="https://avatars.githubusercontent.com/u/85220317?v=4?s=100" width="100px;" alt=""/><br /><sub><b>mdelgadodiaz83-erni</b></sub></a><br /><a href="https://github.com/ERNI-Academy/assets-cloud-servicebus-abstraction/commits?author=mdelgadodiaz83-erni" title="Code">💻</a> <a href="#content-mdelgadodiaz83-erni" title="Content">🖋</a> <a href="https://github.com/ERNI-Academy/assets-cloud-servicebus-abstraction/commits?author=mdelgadodiaz83-erni" title="Documentation">📖</a> <a href="#design-mdelgadodiaz83-erni" title="Design">🎨</a> <a href="#ideas-mdelgadodiaz83-erni" title="Ideas, Planning, & Feedback">🤔</a> <a href="#maintenance-mdelgadodiaz83-erni" title="Maintenance">🚧</a> <a href="https://github.com/ERNI-Academy/assets-cloud-servicebus-abstraction/commits?author=mdelgadodiaz83-erni" title="Tests">⚠️</a> <a href="#example-mdelgadodiaz83-erni" title="Examples">💡</a> <a href="https://github.com/ERNI-Academy/assets-cloud-servicebus-abstraction/pulls?q=is%3Apr+reviewed-by%3Amdelgadodiaz83-erni" title="Reviewed Pull Requests">👀</a></td>
  </tr>
</table>

<!-- markdownlint-restore -->
<!-- prettier-ignore-end -->

<!-- ALL-CONTRIBUTORS-LIST:END -->
This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!
