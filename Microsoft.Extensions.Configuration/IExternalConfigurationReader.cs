using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Microsoft.Extensions.Configuration.External
{
    public interface IExternalConfigurationReader
    {
        Stream Load();
    }
}
