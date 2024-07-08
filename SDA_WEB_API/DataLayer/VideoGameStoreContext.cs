using Microsoft.EntityFrameworkCore;
using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.DataLayer
{
    public class VideoGameStoreContext : DbContext
    {
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public VideoGameStoreContext(DbContextOptions<VideoGameStoreContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
