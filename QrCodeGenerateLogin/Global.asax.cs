using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using QrCodeGenerateLogin;

namespace QrCodeGenerateLogin
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        { 
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }
    }
}
