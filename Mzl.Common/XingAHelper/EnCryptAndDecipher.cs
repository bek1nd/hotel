using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.XingAHelper
{
    /// <summary>
    /// 行啊加解密
    /// </summary>
    public class EnCryptAndDecipher
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Encrypt(string content, string privateKey, string token)
        {
            var md5 = Md5(content);
            var length = md5.Length;
            var rijndael = EncryptRijndael(content, privateKey, token);
            //var s = DecryptRijndael(rijndael, privateKey, token);
            return length.ToString("D8") + md5 + rijndael;
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Decrypt(string content, string privateKey, string token)
        {
            try
            {
                var lengthStr = content.Substring(0, 8);
                int length = int.Parse(lengthStr);
                content = content.Substring(8);
                var md5 = content.Substring(0, length);
                content = content.Substring(length);
                var plainText = DecryptRijndael(content, privateKey, token);
                if (Md5(plainText) != md5)
                {
                    throw new Exception();
                }

                return plainText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 数据加密
        /// </summary>
        /// <param name="content">加密文本</param>
        /// <param name="privateKey">私钥</param>
        /// <param name="token">公钥</param>
        /// <returns></returns>
        private static string EncryptRijndael(string content, string privateKey, string token)
        {
            byte[] encrypted;
            byte[] plainText = Encoding.UTF8.GetBytes(content);
            using (Rijndael rijAlg = Rijndael.Create())
            {
                byte[] Key = new byte[32];
                byte[] IV = new byte[16];

                Key = Encoding.UTF8.GetBytes(token).Take(32).ToArray();
                IV = Encoding.UTF8.GetBytes(privateKey).Take(16).ToArray();

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(Key, IV);
                encrypted = encryptor.TransformFinalBlock(plainText, 0, plainText.Length);
            }
            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// 数据解密
        /// </summary>
        /// <param name="content">解密文本</param>
        /// <param name="privateKey">私钥</param>
        /// <param name="token">公钥</param>
        /// <returns></returns>
        private static string DecryptRijndael(string content, string privateKey, string token)
        {
            var con = Convert.FromBase64String(content);
            byte[] decrypted;
            using (Rijndael rijAlg = Rijndael.Create())
            {
                byte[] Key = new byte[32];
                byte[] IV = new byte[16];

                Key = Encoding.UTF8.GetBytes(token).Take(32).ToArray();
                IV = Encoding.UTF8.GetBytes(privateKey).Take(16).ToArray();

                // Create an encryptor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(Key, IV);

                decrypted = decryptor.TransformFinalBlock(con, 0, con.Length);
                return Encoding.UTF8.GetString(decrypted);
            }
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="content">加密文本</param>
        /// <returns>加密结果</returns>
        public static string Md5(string content)
        {
            var result = Encoding.UTF8.GetBytes(content.Trim());
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return Convert.ToBase64String(output);
        }
    }
}
