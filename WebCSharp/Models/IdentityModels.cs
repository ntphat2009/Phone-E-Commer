using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebCSharp.Models.EntityFrameWork;

namespace WebCSharp.Models
{

    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manage)

        {
            var userIdentity = await manage.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            :  base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contact> Contacts { get; set; }
     
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductStore> ProductStore { get; set; }
        public DbSet<Config> Configs { get; set; }

        public DbSet<ProductSale> ProductSale { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }


        public DbSet<Slider> Sliders { get; set; }

        public DbSet<User> Users { get; set; }

        public static ApplicationDbContext Create()
        {
                return new ApplicationDbContext();
        }
    }
    

}