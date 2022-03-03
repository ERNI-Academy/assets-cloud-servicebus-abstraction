using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Abstraction.Config
{
    public interface ISBConfig
    {
        public string ConnectionString { get; set; }
        public string Topic { get; set; }
        public string Subscription { get; set; }

    }
}
