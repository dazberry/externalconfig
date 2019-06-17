using System.IO;

namespace Microsoft.Extensions.Configuration.External
{
    public interface IExternalConfigurationReader
    {
        Stream Load();
    }
}
