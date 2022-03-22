using SB.Abstraction.Contract.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SB.Abstraction.Model
{
    public class SBMessage : IMessage
    {
        public dynamic Value { get; set; }
        public Guid Key { get; set; }    

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
