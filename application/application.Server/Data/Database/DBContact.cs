using application.Server.Data.Model;
using application.Server.Init;
using Microsoft.EntityFrameworkCore;

namespace application.Server.Data.Database
{
    public class DBContact: DbContext
    {
        public DBContact(DbContextOptions<DBContact> options): base(options) {  }

        public DbSet<Contact> contacts => Set<Contact>();
        public DbSet<User> users => Set<User>();
    }
}
