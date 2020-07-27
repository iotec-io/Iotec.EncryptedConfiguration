using Microsoft.Extensions.Configuration;

namespace Iotec.EncryptedConfiguration
{
    public class EncryptedJsonConfigurationSource : IConfigurationSource
    {
        public string FileName { get; set; }
        public string EncryptionKey { get; set; }

        public EncryptedJsonConfigurationSource(string fileName, string encryptionKey)
        {
            FileName = fileName;
            EncryptionKey = encryptionKey;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new EncryptedJsonProvider(this);
        }
    }
}