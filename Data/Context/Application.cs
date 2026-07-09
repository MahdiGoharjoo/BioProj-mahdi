using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class Application : DbContext
    {
        public Application() {}
        public Application( DbContextOptions<Application> options) : base(options) { } 
        public DbSet<Tbl_First> tbl_First { get; set; }
        public DbSet<Tbl_AboutMe> tbl_Aboutme { get; set; }
        public DbSet<Tbl_AllAboutMe> tbl_Allaboutme { get; set; }
        public DbSet<Tbl_Blog> tbl_Blog { get; set; }
        public DbSet<Tbl_Comments> tbl_Comments { get; set; }
        public DbSet<Tbl_ContactUsClient> tbl_Contactusclients { get; set; }
        public DbSet<Tbl_Customers> tbl_Customers { get; set; }
        public DbSet<Tbl_Projects> tbl_Projects { get; set; }
        public DbSet<Tbl_Serrvices> tbl_Serrvices { get; set; }
        public DbSet<Tbl_Statics> tbl_Statics { get; set; }
        public DbSet<Tbl_ContactUsAdmin> tbl_ContactUsAdmins {get; set; }
        public DbSet<Tbl_User> tbl_Users {get ; set;}  
    }
    public class ToDoContextFactory : IDesignTimeDbContextFactory<Application>
    {
        public ToDoContextFactory() { }

        public Application CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Application>();
            builder.UseSqlServer(
                "Data Source=.;initial Catalog=Bio;integrated Security=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=True"
            );
            //  builder.UseSqlServer("Data Source=193.141.64.76,2019;initial Catalog=hampadco;USER ID=hampadco;PASSWORD=12345@iran;MultipleActiveResultSets=true");


            return new Application(builder.Options);
        }
    }
    
}