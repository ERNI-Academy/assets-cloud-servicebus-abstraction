using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Abstraction.Contract.Models
{
    interface IAbstractMessage
    {
        Guid Id { get; }
    }
}
