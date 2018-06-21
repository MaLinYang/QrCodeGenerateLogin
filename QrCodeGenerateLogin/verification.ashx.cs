using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace QrCodeGenerateLogin
{
    /// <summary>
    /// verification 的摘要说明
    /// </summary>
    public class verification : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var uuid = context.Request["uuid"] ?? "";
            var islogin = false;
            var cache_key = string.Format(@"applogin:{0}", uuid);
            var user = UserLoginPoolCache.GetCache(cache_key);
            if (user != null)
            {
                islogin = true;
            }
            if (islogin)
            {
                context.Response.Write("{\"errorcode\":\"200\",\"qrcode\":\"" + uuid + "\"}");
                context.Response.AddHeader("Connection", "close");
            }
            else
            {
                context.Response.AddHeader("Connection", "keep-alive");
                Thread.Sleep(10000);
                context.Response.Write("{\"errorcode\":\"408\",\"qrcode\":\"" + uuid + "\"}");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}