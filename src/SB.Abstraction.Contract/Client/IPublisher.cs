using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Abstraction.Contract.Client
{
    interface IPublisher
    {
        void Send(dynamic message);
    }
}
