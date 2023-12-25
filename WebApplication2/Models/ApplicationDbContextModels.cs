using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication2.Models
{
    // 应用程序数据库上下文，继承自 IdentityDbContext，并使用 ApplicationUser 作为用户实体
    public class ApplicationDbContextModels : IdentityDbContext<ApplicationUserModels>
    {
        // 引用自定义models
        public DbSet<CustomerModels> Customers { get; set; }
        public DbSet<BookModels> Books { get; set; }
        public DbSet<MembershipTypeModels> MembershipTypes { get; set; }
        public DbSet<RentalViewModels> Rentals { get; set; }
        // 默认构造函数，使用指定的连接字符串（"DefaultConnection"）并指定不抛出异常
        public ApplicationDbContextModels()
            : base("DefaultConnection", throwIfV1Schema: false){}

        // 静态工厂方法，用于创建 ApplicationDbContext 实例
        public static ApplicationDbContextModels Create()
        {
            // 返回新的 ApplicationDbContext 实例
            return new ApplicationDbContextModels();
        }
    }
}
