namespace BuilderPulsePro.Domain.Shared.Options
{
    public class KeyOptions
    {
        public GoogleOptions Google { get; set; }
        public AzureOptions Azure { get; set; }
    }

    public class GoogleOptions
    {
        public string MapsApiKey { get; set; }
    }

    public class AzureOptions
    {
        public string BlobStorageConnectionString { get; set; }
    }
}
