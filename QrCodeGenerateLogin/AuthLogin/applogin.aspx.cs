using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrCodeGenerateLogin.AuthLogin
{
    public partial class applogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var uuid = Request["uuid"] ?? "";
            var authid = Request["authid"] ?? "";
            var lguserid = Request["lguserid"] ?? "U001";

            var cache_key = string.Format(@"applogin:{0}", uuid);
            if (string.IsNullOrEmpty(uuid) || string.IsNullOrEmpty(authid) || string.IsNullOrEmpty(lguserid))
            {
                Response.Write("授权失败！");
            }
            else
            {
                UserInfo user = new UserInfo();
                user.UID = "001";
                user.AuthId = authid;
                user.Name = "小名";
                user.UserAvatar = "http://172.31.35.26:6060/Images/001.jpg";
                user.UUID = uuid;
                UserLoginPoolCache.SetCache(cache_key, user, TimeSpan.FromHours(2));
            }
        }
    }
}