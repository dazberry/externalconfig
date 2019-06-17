namespace Microsoft.Extensions.Configuration.External
{
    public class ExternalConfigurationSource : IConfigurationSource
    {
        public IExternalConfigurationReader ExternalConfigurationReader { get; set; }        

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new ExternalConfigurationProvider(ExternalConfigurationReader);
        }
    }
}
