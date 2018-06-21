# QrCodeGenerateLogin 扫码登录

### 项目QrCodeGenerateLogin

> 用[C#](“语言”)编写的扫码登录案例
> 
- - - 
> ##代码说明
> 1.打开index.aspx页面生成二维码，并生成二维码唯一码（uuid）,并请求验证二维码的地址（../verification.ashx）

> 2.index.aspx页面会收到服务器的反馈，如果没有验证成功的话，会再次发起请求

> 3.打开手机扫码确认,会调用二维码内的校验地址../AuthLogin/applogin.aspx，这时候绑定验证码唯一码

> 4.index.aspx再次请求验证二维码唯一码的时候获得用户绑定信息后，直接跳转登录成功页面（../default.aspx）
