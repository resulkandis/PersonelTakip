using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PT.DL;
using PT.Entity.IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.BL.AccountRepository
{
    public class MemberShipTools
    {
        public static UserStore<ApplicationUser> NewUserStore() => new UserStore<ApplicationUser>(new MyContext());
        public static UserManager<ApplicationUser> NewUserManager() => new UserManager<ApplicationUser>(NewUserStore());

        public static RoleStore<ApplicationRole> NewRoleStore() => new RoleStore<ApplicationRole>(new MyContext());
        public static RoleManager<ApplicationRole> NewManager() => new RoleManager<ApplicationRole>(NewRoleStore());
    }
}
