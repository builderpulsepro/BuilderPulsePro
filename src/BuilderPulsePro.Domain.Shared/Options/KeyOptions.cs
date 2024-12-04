namespace BuilderPulsePro.Domain.Shared.Options
{
    public class KeyOptions
    {
        public GoogleOptions Google { get; set; }
        public AzureOptions Azure { get; set; }
        public RedisOptions Redis { get; set; }
        public ConnectionStringOptions ConnectionStrings { get; set; }
    }

    public class GoogleOptions
    {
        public string MapsApiKey { get; set; }
    }

    public class AzureOptions
    {
        public string BlobStorageConnectionString { get; set; }
    }

    public class RedisOptions
    {
        public string Configuration { get; set; }
    }

    public class ConnectionStringOptions
    {
        public string Default { get; set; }
    }
}
