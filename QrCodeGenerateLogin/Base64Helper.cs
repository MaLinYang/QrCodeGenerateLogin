using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace QrCodeGenerateLogin
{
    /// <summary>
    /// Base64Helper
    /// </summary>
    public class Base64Helper
    {

        /// <summary>
        /// Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string Base64Encode(string source)
        {
            return Base64Encode(Encoding.UTF8, source);
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="encodeType">加密采用的编码方式</param>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string Base64Encode(Encoding encodeType, string source)
        {
            string encode = string.Empty;
            byte[] bytes = encodeType.GetBytes(source);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = source;
            }
            return encode;
        }

        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(string result)
        {
            return Base64Decode(Encoding.UTF8, result);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="encodeType">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(Encoding encodeType, string result)
        {
            string decode = string.Empty;
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encodeType.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }



        //方法二
        //有一种加密方式：明文加密之后生成长度是24位的密文，而且密文以=结尾。经查询后发现大家都说这种加密方式是Base64加密，不过这种加密方式与方法一中的Base64加密不一样，具体代码如下

        //string original = "123456";

        //   var md5 = BitConverter.ToString(new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(original))).Replace("-", "").ToLower();
        //   Console.WriteLine("md5=" + md5);

        //   //b64是以=结尾的长度为24位的密文
        //   var b64 = Convert.ToBase64String(new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(original)));
        //   Console.WriteLine("b64=" + b64);

        //   var dec = BitConverter.ToString(new System.Security.Cryptography.FromBase64Transform().TransformFinalBlock(Encoding.Default.GetBytes(b64), 0, Encoding.Default.GetBytes(b64).Length)).Replace("-","").ToLower();
        //   Console.WriteLine("dec=" + dec);
        //   Console.ReadLine();   
    }
}