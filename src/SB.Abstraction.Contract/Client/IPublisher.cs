using SB.Abstraction.Contract.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Abstraction.Contract.Client
{
    public interface IPublisher:IClient
    {
        void SendAsync(IMessage message);
    }
}
