using backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Database
{
    public class DBContact: DbContext
    {
        public DBContact(DbContextOptions<DBContact> options): base(options) { }

        public DbSet<Contact> Todos => Set<Contact>();
    }
}
