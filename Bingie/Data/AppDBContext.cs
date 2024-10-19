using Microsoft.EntityFrameworkCore;
using System.IO;
using Bingie.Models;

namespace Bingie.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _dbPath;

        public AppDbContext(string dbPath)
        {
            _dbPath = dbPath;
            Database.EnsureCreated(); // Create the database if it doesn't exist
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
        }
    }
}
