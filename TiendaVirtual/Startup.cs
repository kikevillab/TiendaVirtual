using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TiendaVirtual.Startup))]
namespace TiendaVirtual
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            Models.ApplicationDbContext context = new Models.ApplicationDbContext();

            var UserManager = new UserManager<Models.ApplicationUser>(new UserStore<Models.ApplicationUser>(context));

            Models.ApplicationUser admin = UserManager.FindByEmail("admin@admin.com");
            if(admin == null)
            {
                admin = new Models.ApplicationUser{ UserName = "admin@admin.com", Email = "admin@admin.com" };
                UserManager.Create(admin, "1234%Aa");
            }
        }
    }
}
