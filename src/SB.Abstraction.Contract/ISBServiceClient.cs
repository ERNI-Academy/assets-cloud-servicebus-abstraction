using SB.Abstraction.Contract.Client;

namespace SB.Abstraction.Contract
{
    public interface ISBServiceClient
    {
        IListener GetListener(string topicName = "");
        IPublisher GetPublisher(string topicName = "");
    }
}
