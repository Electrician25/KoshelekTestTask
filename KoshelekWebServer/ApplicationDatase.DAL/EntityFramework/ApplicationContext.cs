using DatabaseLevel.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLevel.DAL.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Message> Messages { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            Database.EnsureCreated();
        }
    }
}