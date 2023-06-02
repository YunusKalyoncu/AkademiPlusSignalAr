using Microsoft.EntityFrameworkCore;

namespace AkademiPlusSignalAr.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=YUNUS\\SQLEXPRESS;initial catalog=AkademiPlusSignalR;integrated security=true;");
        }
        public DbSet<User> users { get; set; }
        public DbSet<Room> rooms  { get; set; }
    }
}
