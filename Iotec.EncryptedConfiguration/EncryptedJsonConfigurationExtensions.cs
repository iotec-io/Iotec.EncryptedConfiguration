using System;
using Microsoft.Extensions.Configuration;

namespace Iotec.EncryptedConfiguration
{
    public static class EncryptedJsonConfigurationExtensions
    {
        public static IConfigurationBuilder AddEncryptedJson(this IConfigurationBuilder configuration,
            string filename, string encryptionKey=null)
        {
            _ = filename ?? throw new ArgumentNullException(nameof(filename));
            configuration.Add(source: new EncryptedJsonConfigurationSource(filename, encryptionKey));
            return configuration;
        }
    }
}