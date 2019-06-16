using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.External;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace ConsoleApp1
{

    public class TestConfigurationReader : IExternalConfigurationReader
    {
        public Stream Load()
        {
            var s = JsonConvert.SerializeObject(new { key = "darren", key2 = 1 });
            byte[] byteArray = Encoding.ASCII.GetBytes(s);
            MemoryStream ms = new MemoryStream(byteArray);
            return ms;           
        }
    }

    class Program
    {
        

        static void Main(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //    .AddExternalConfiguration(new TestConfigurationReader())
            //    .Build();


            //var value = configuration["key"];
            //var value2 = configuration["key2"];
            //Console.WriteLine($"value: {value}, value2: {value2}");
            //Console.ReadKey();
        }
    }
}
