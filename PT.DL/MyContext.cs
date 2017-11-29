using Microsoft.AspNet.Identity.EntityFramework;
using PT.Entity.IdentityModel;
using PT.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.DL
{
    public class MyContext:IdentityDbContext<ApplicationUser>
    {
        public MyContext()
            :base("name=MyCon")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) //bu e mail teklil metodu ama çalışmıyo nedense 
        {
            base.OnModelCreating(modelBuilder);
            this.RequireUniqueEmail = true;
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<LaborLog> LaborLogs { get; set; }
        public virtual DbSet<SalaryLog> SalaryLogs { get; set; }
    }
}
