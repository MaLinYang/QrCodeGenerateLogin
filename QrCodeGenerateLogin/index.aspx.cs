using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrCodeGenerateLogin
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var random = new Random();
            var uuid = Base64Helper.Base64Encode(random.Next(0, int.MaxValue) + "_" + DateTime.Now.GetHashCode());
            var authid = "authid";
            var url = "http://172.31.35.26:6060/AuthLogin/applogin.aspx?uuid=" + uuid + "&authid=" + authid;
            var imgfilename = @"qrcode\" + uuid + ".jpg";
            //var localpath= HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录 
            var localpath = System.AppDomain.CurrentDomain.BaseDirectory + imgfilename;//获取程序根目录
            //QrCodeSystem.Generate1(url);
            QrCodeSystem.Generate2(url, localpath);
            Img_qrcode.ImageUrl = "http://172.31.35.26:6060/" + imgfilename;
            Img_qrcode.AlternateText = uuid;
            var islogin = false;
            var user = UserLoginPoolCache.GetCache(uuid) as UserInfo;
            if (user != null)
            {
                islogin = true;
                Response.AddHeader("Connection", "close");
                //new Thread(() =>
                //{
                Img_qrcode.ImageUrl = user.UserAvatar;
                //}) { IsBackground = true }.Start();
                //Thread.Sleep(5000);
            }
            Response.AddHeader("Connection", "keep-alive");
            //if (islogin)
            //{

            //    //Server.Transfer("default.aspx?uuid=" + uuid, false);
            //    //Response.Redirect("default.aspx?uuid=" + uuid, false);
            //}

        }
    }
}