using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication2.Models
{
    // 可以通过将更多属性添加到 ApplicationUser 类来为用户添加配置文件数据，请访问 https://go.microsoft.com/fwlink/?LinkID=317594 了解详细信息。

    // 用户实体类，继承自 IdentityUser 类
    public class ApplicationUser : IdentityUser
    {
        // 生成用户身份异步方法，用于创建用户标识
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            // 使用 UserManager 创建用户标识
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 返回生成的用户标识
            return userIdentity;
        }
    }

    // 应用程序数据库上下文，继承自 IdentityDbContext，并使用 ApplicationUser 作为用户实体
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // 定义引用自定义models
        public DbSet<CustomerModels> Customers { get; set; }
        public DbSet<BookModels> Books { get; set; }
        public DbSet<MembershipTypeModels> MembershipTypes { get; set; }
        // 默认构造函数，使用指定的连接字符串（"DefaultConnection"）并指定不抛出异常
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // 静态工厂方法，用于创建 ApplicationDbContext 实例
        public static ApplicationDbContext Create()
        {
            // 返回新的 ApplicationDbContext 实例
            return new ApplicationDbContext();
        }
    }
}
