using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QrCodeGenerateLogin
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var uuid = Request["uuid"] ?? "";

            var cache_key = string.Format(@"applogin:{0}", uuid.Trim(' '));

            var user = (UserInfo)UserLoginPoolCache.GetCache(cache_key);
            if (user != null)
            {
                lab_msg.Text = user.Name;
                img_user.ImageUrl = user.UserAvatar;
            }
        }
    }
}