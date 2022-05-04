using System;

namespace SB.Abstraction.Contract.Models
{
    public interface IAbstractMessage
    {
        Guid Key { get; }
    }
}
