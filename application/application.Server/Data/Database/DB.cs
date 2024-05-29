using application.Server.Data.Model;
using application.Server.Init;
using Microsoft.EntityFrameworkCore;

namespace application.Server.Data.Database
{
    public class DB: DbContext
    {
        public DB(DbContextOptions<DB> options): base(options) {  }

        public DbSet<Contact> contacts => Set<Contact>();
        public DbSet<User> users => Set<User>();
        public DbSet<Category> category => Set<Category>();
    }
}
