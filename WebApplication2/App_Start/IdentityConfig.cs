using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using WebApplication2.Models;

namespace WebApplication2
{
    // 配置此应用程序中使用的应用程序用户管理器。UserManager 在 ASP.NET Identity 中定义，并由此应用程序使用。
    public class ApplicationUserManager : UserManager<ApplicationUserModels>
    {
        // 构造函数，接受一个用户存储对象（通常是数据库上下文）作为参数
        public ApplicationUserManager(IUserStore<ApplicationUserModels> store)
            : base(store)
        {
        }

        // 静态工厂方法，用于创建 ApplicationUserManager 实例
        public static ApplicationUserManager Create(IOwinContext context)
        {
            // 创建 ApplicationUserManager 实例，使用给定的用户存储对象
            var manager = new ApplicationUserManager(new UserStore<ApplicationUserModels>(context.Get<ApplicationDbContextModels>()));

            // 配置用户名的验证逻辑
            manager.UserValidator = new UserValidator<ApplicationUserModels>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // 配置密码的验证逻辑
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // 配置用户锁定默认值
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // 返回配置好的 ApplicationUserManager 实例
            return manager;
        }
    }

    // 配置要在此应用程序中使用的应用程序登录管理器。
    public class ApplicationSignInManager : SignInManager<ApplicationUserModels, string>
    {
        // 构造函数，接受 ApplicationUserManager 和身份验证管理器作为参数
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        // 重写的方法，用于异步创建用户标识
        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUserModels user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        // 静态工厂方法，用于创建 ApplicationSignInManager 实例
        public static ApplicationSignInManager Create(IOwinContext context)
        {
            // 使用给定的 IOwinContext 创建 ApplicationSignInManager 实例
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
