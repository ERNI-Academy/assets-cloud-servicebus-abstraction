using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Abstraction.Contract
{
    public interface ISBServiceClient
    {
        object GetListener();
        object GetPublisher(string topicName = "");
    }
}
