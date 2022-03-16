using SB.Abstraction.Contract.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Abstraction.Contract
{
    public interface ISBServiceClient
    {
        IListener GetListener(string topicName = "");
        IPublisher GetPublisher(string topicName = "");
    }
}
