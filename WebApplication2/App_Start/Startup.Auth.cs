﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using WebApplication2.Models;

namespace WebApplication2
{
    public partial class Startup
    {
        // 有关配置身份验证的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // 配置数据库上下文、用户管理器和登录管理器，以便为每个请求使用单个实例
            app.CreatePerOwinContext(ApplicationDbContextModels.Create);
            app.CreatePerOwinContext<ApplicationUserManager>((options, context) => ApplicationUserManager.Create(context));
            app.CreatePerOwinContext<ApplicationSignInManager>((options, context) => ApplicationSignInManager.Create(context));


            // 使应用程序可使用 Cookie 存储登录用户的信息
            // 并使用 Cookie 来临时存储有关使用第三方登录提供程序登录的用户的信息
            // 配置登录 Cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // 当用户登录时使应用程序可以验证安全戳。
                    // 这是一项安全功能，当你更改密码或者向账号添加外部登录名时，将使用此功能。
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUserModels>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
        }
    }
}