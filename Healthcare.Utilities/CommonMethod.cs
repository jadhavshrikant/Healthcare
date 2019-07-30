#region Namespace
using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Web.Script.Serialization;
#endregion

namespace Healthcare.Utilities
{
    /// <summary>
    /// CommonMethod
    /// </summary>
    public class CommonMethod
    {
        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// EncryptStringToBytes_Aes
        /// https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=netframework-4.8
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static byte[] EncryptStringToBytes_Aes(string plainText)
        {
            // Create a new instance of the Aes
            // class.  This generates a new key and initialization 
            // vector (IV).
            using (Aes myAes = Aes.Create())
            {
                // Check arguments.
                if (plainText == null || plainText.Length <= 0)
                    throw new ArgumentNullException("plainText");

                byte[] encrypted;

                // Create an Aes object
                // with the specified key and IV.
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = myAes.Key;
                    aesAlg.IV = myAes.IV;

                    // Create an encryptor to perform the stream transform.
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for encryption.
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                swEncrypt.Write(plainText);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }
                // Return the encrypted bytes from the memory stream.
                return encrypted;
            }
        }

        /// <summary>
        /// DecryptStringFromBytes_Aes
        /// https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=netframework-4.8
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public static string DecryptStringFromBytes_Aes(byte[] cipherText)
        {
            // Create a new instance of the Aes
            // class.  This generates a new key and initialization 
            // vector (IV).
            using (Aes myAes = Aes.Create())
            {
                // Check arguments.
                if (cipherText == null || cipherText.Length <= 0)
                    throw new ArgumentNullException("cipherText");

                // Declare the string used to hold
                // the decrypted text.
                string plaintext = null;

                // Create an Aes object
                // with the specified key and IV.
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = myAes.Key;
                    aesAlg.IV = myAes.IV;

                    // Create a decryptor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for decryption.
                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                return plaintext;
            }
        }

        /// <summary>
        /// ConvertObjectToJsonString
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ConvertObjectToJsonString<T>(T input)
        {
            string jsonStr = JsonConvert.SerializeObject(input);
            return jsonStr;
        }

        /// <summary>
        /// ConvertJsonStringToObject
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public static T ConvertJsonStringToObject<T>(string output)
        {
            T convertedObject = JsonConvert.DeserializeObject<T>(output);
            return convertedObject;
        }

        #endregion
    }
}
