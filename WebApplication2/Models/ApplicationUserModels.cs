using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication2.Models
{
    // 可以通过将更多属性添加到 ApplicationUser 类来为用户添加配置文件数据，请访问 https://go.microsoft.com/fwlink/?LinkID=317594 了解详细信息。

    // 用户实体类，继承自 IdentityUser 类
    public class ApplicationUserModels : IdentityUser
    {
        // 生成用户身份异步方法，用于创建用户标识
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUserModels> manager)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            // 使用 UserManager 创建用户标识
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 返回生成的用户标识
            return userIdentity;
        }
        
    }
}