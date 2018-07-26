using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Mzl.Common.MD5Helper
{
    public class MD5Helper
    {


        static string MD5Key = "U7yyowJiVyawLUd3ZDgVWeHdvGrnVtH9zJe"; //加密前数据 //hxf7COYKQN7JwRkQbVQIrr6Lo0jbH9I


        /// <summary>
        /// 字符串MD5加密
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string tempStr)
        {

            MD5 md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(tempStr));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }


            return sb.ToString();
        }

        /// <summary>
        /// 通过MD5生成通用输入参数中的Sign
        /// </summary>
        /// <param name="partnerid"></param>
        /// <param name="methodname"></param>
        /// <param name="nowtime"></param>
        /// <returns></returns>
        public static string GetSign(string partnerid, string methodname, string nowtime)
        {
            if (methodname == "train_query")
            {
                MD5Key = "zhxf7COYKQN7JwRkQbVQIrr6Lo0jbH9I";
            }
            else
            {
                MD5Key = "U7yyowJiVyawLUd3ZDgVWeHdvGrnVtH9zJe";
            }
            string AfterMD5Key = MD5Encrypt(MD5Key);
            string nextkey = partnerid + methodname + nowtime + AfterMD5Key;
            return MD5Encrypt(nextkey).ToLower();
        }


        /// <summary>
        /// 通过MD5生成线上退票或线上改签数字签名
        /// </summary>
        /// <param name="partnerid"></param>
        /// <param name="returntype"></param>
        /// <param name="timestamp"></param>
        /// <param name="apiorderid"></param>
        /// <param name="trainorderid"></param>
        /// <param name="returnmoney"></param>
        /// <param name="returnstate"></param>
        /// <returns></returns>
        public static string GetSign(string partnerid, string returntype, string timestamp, string apiorderid,
            string trainorderid, string returnmoney, string returnstate)
        {
            string AfterMD5Key = MD5Encrypt(MD5Key);

            string nextkey = partnerid + returntype + timestamp + apiorderid + trainorderid + returnmoney + returnstate +
                             AfterMD5Key;
            return MD5Encrypt(nextkey).ToLower();
        }




        /// <summary>
        /// 通过MD5生成线上退票或线上改签数字签名
        /// </summary>
        /// <param name="partnerid"></param>
        /// <param name="returntype"></param>
        /// <param name="timestamp"></param>
        /// <param name="apiorderid"></param>
        /// <param name="trainorderid"></param>
        /// <param name="token"></param>
        /// <param name="returnmoney"></param>
        /// <param name="returnstate"></param>
        /// <returns></returns>
        public static string GetSign(string partnerid, string returntype, string timestamp, string apiorderid,
            string trainorderid, string token, string returnmoney, string returnstate)
        {
            string AfterMD5Key = MD5Encrypt(MD5Key);

            string nextkey = partnerid + returntype + timestamp + apiorderid + trainorderid + token + returnmoney +
                             returnstate + AfterMD5Key;
            return MD5Encrypt(nextkey).ToLower();
        }

    }
}
