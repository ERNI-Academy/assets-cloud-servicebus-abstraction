namespace SB.Abstraction.Config
{
    public class SBConfig : ISBConfig
    {
        public string ConnectionString { get; set; }
        public string Topic { get ; set ; }
        public string Subscription { get ; set ; }
    }
}
