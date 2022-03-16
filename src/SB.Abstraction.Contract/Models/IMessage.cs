using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Abstraction.Contract.Models
{
    public interface IMessage : IAbstractMessage
    {
        dynamic Value { get; }
    }
}
