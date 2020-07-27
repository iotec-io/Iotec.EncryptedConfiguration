using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Iotec.EncryptedConfiguration
{
    public static class EncryptionUtils
    {
        public static void Encrypt(string inputFile, string outputFile, string sKey = "Ep6:~>ac")
        {
            var fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            var outputStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write);

            var des = new DESCryptoServiceProvider
            {
                Key = Encoding.ASCII.GetBytes(sKey),
                IV = Encoding.ASCII.GetBytes(sKey)
            };
            var cryptoTransform = des.CreateEncryptor();
            var cryptoStream = new CryptoStream(outputStream, cryptoTransform, CryptoStreamMode.Write);

            var inputBytArray = new byte[fsInput.Length];
            fsInput.Read(inputBytArray, 0, inputBytArray.Length);
            cryptoStream.Write(inputBytArray, 0, inputBytArray.Length);
            cryptoStream.Close();
            fsInput.Close();
            outputStream.Close();
        }

        public static void Decrypt(string inputFile, string outputFile, string sKey = "Ep6:~>ac")
        {
            //A 64 bit key and IV is required for this provider.
            //Set secret key For DES algorithm.
            //Set initialization vector.
            var des = new DESCryptoServiceProvider
            {
                Key = Encoding.ASCII.GetBytes(sKey), IV = Encoding.ASCII.GetBytes(sKey)
            };
            //Create a file stream to read the encrypted file back.
            var inputStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            //Create a DES decryptor from the DES instance.
            var cryptoTransform = des.CreateDecryptor();
            //Create crypto stream set to read and do a 
            //DES decryption transform on incoming bytes.
            var cryptoStream = new CryptoStream(inputStream, cryptoTransform, CryptoStreamMode.Read);
            //Print the contents of the decrypted file.
            var fsDecrypted = new StreamWriter(outputFile);
            fsDecrypted.Write(new StreamReader(cryptoStream).ReadToEnd());
            fsDecrypted.Flush();
            fsDecrypted.Close();
        }

        public static string Decrypt(string inputFile, string sKey = "Ep6:~>ac")
        {
            //A 64 bit key and IV is required for this provider.
            //Set secret key For DES algorithm.
            //Set initialization vector.
            var des = new DESCryptoServiceProvider
            {
                Key = Encoding.ASCII.GetBytes(sKey),
                IV = Encoding.ASCII.GetBytes(sKey)
            };
            //Create a file stream to read the encrypted file back.
            var inputStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            //Create a DES decryptor from the DES instance.
            var cryptoTransform = des.CreateDecryptor();
            //Create crypto stream set to read and do a 
            //DES decryption transform on incoming bytes.
            var cryptoStream = new CryptoStream(inputStream, cryptoTransform, CryptoStreamMode.Read);
            //Print the contents of the decrypted file.
            return new StreamReader(cryptoStream).ReadToEnd();
        }
    }
}