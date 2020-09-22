using System.Linq;
using CRUD.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUD.Startup))]
namespace CRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           // PopulateUserAndRoles();
        }

        public void PopulateUserAndRoles()
        {
            var db = new ApplicationDbContext();

            if (!db.Roles.Any(x => x.Name == MyConstants.RoleAdmin))
            {
                db.Roles.Add(new IdentityRole {Name = MyConstants.RoleAdmin });
                db.SaveChanges();
            }

            if (!db.Roles.Any(x => x.Name == MyConstants.RoleUser))
            {
                db.Roles.Add(new IdentityRole { Name = MyConstants.RoleUser });
                db.SaveChanges();
            }

            if (!db.Users.Any(x => x.UserName == "appadmin"))
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new ApplicationUserManager(userStore);

                var roleStore = new RoleStore<IdentityRole>(db);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var newUser = new ApplicationUser
                {
                    Email = "appadmin@test.com",
                    UserName = "appadmin"
                };

                userManager.Create(newUser, "applicationadmin");
                userManager.AddToRole(newUser.Id, MyConstants.RoleAdmin);
                db.SaveChanges();
            }
        }
    }
}
