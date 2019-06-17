using System.IO;

namespace Microsoft.Extensions.Configuration.External
{
    public class ExternalConfigurationProvider : ConfigurationProvider
    {
        private readonly IExternalConfigurationReader _externalConfigurationReader;                

        public ExternalConfigurationProvider(IExternalConfigurationReader externalConfigurationReader)
        {
            _externalConfigurationReader = externalConfigurationReader;
        }
       
        public override void Load()
        {
            var result = _externalConfigurationReader.Load();            
            Load(result);
        }

        internal void Load(Stream stream)
        {
            Data = JsonConfigurationFileParser.Parse(stream);
        }

    }
}
