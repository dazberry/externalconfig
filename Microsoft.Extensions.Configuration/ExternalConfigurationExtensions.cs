using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Microsoft.Extensions.Configuration.External
{
    public static class ExternalConfigurationExtensions
    {
        public static IWebHostBuilder UseExternalConfiguration(this IWebHostBuilder webhostBuilder, HttpMethod httpMethod, Uri requestUri)
        {
            var reader = new ExternalConfigurationReader()
            {
                HttpMethod = httpMethod,
                RequestUri = requestUri
            };
            return webhostBuilder.ConfigureAppConfiguration((context, builder) =>
            {
                builder.Add(new ExternalConfigurationSource()
                {
                    ExternalConfigurationReader = reader
                });
            });               
        }

        public static IWebHostBuilder UseExternalConfiguration<T>(this IWebHostBuilder webhostBuilder, HttpMethod httpMethod, Uri requestUri, T content, string contentType)
        {
            var reader = new ExternalConfigurationReader<T>()
            {
                HttpMethod = httpMethod,
                RequestUri = requestUri,
                Content = content,
                ContentType = contentType
            };

            return webhostBuilder.ConfigureAppConfiguration((context, builder) =>
            {
                builder.Add(new ExternalConfigurationSource()
                {
                    ExternalConfigurationReader = reader
                });
            });
        }

    }
}
