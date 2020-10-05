
using Microsoft.Data.SqlClient;
using LifeBonder.MessageService.Api.DataAccess.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using LifeBonder.MessageService.Api.DataAccess.Models;

namespace LifeBonder.MessageService.Api.DataAccess
{
    public class MessageDbContext:DbContext
    {
        private readonly IOptions<DatabaseSettings> _databaseSettings;

        public DbSet<UserMessage> UserMessages { get; set; }

        public DbSet<UserContact> UserContacts { get; set; }

        public MessageDbContext(IOptions<DatabaseSettings> databaseSettings,DbContextOptions<MessageDbContext> options)
            :base(options)
        {
            _databaseSettings = databaseSettings;
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder b)
        {
            if (b.IsConfigured)
                return;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _databaseSettings.Value.ConnectionString;

            b.UseSqlServer(conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMessage>().ToTable(nameof(UserMessage));

            modelBuilder.Entity<UserContact>().ToView(nameof(UserContact));

        }
    }
}
