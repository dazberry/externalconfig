using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Microsoft.Extensions.Configuration.External
{
    public class ExternalConfigurationReader : IExternalConfigurationReader
    {
        public HttpMethod HttpMethod { get; set; }
        public Uri RequestUri { get; set; }               
        public Action<HttpRequestMessage> OnBeforeLoad { get; set; }

        public virtual HttpContent GetContent() => null;
        
        public virtual Stream Load()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod,
                RequestUri = RequestUri,
                Content = GetContent()
            };
            
            OnBeforeLoad?.Invoke(requestMessage);           

            var result = client.SendAsync(requestMessage).Result;
            result.EnsureSuccessStatusCode();
            return result.Content.ReadAsStreamAsync().Result;
        }
    }

    public class ExternalConfigurationReader<T> : ExternalConfigurationReader
    {
        public T Content { get; set; }        
        public string ContentType { get; set; }
        public override HttpContent GetContent()
        {
            var json = JsonConvert.SerializeObject(Content);
            var stringContent = new StringContent(json);
            if (!string.IsNullOrEmpty(ContentType))
                stringContent.Headers.ContentType =
                    new MediaTypeHeaderValue(ContentType);
            return stringContent;
        }
    }
}
