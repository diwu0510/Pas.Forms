using Microsoft.EntityFrameworkCore;
using Pas.Forms.Website.Controllers;

namespace Pas.Forms.Website.Data
 {
    public class FormsDbContext : DbContext
    {
        public FormsDbContext(DbContextOptions<FormsDbContext> options) : base(options)
        { }
        
        public DbSet<Db> Dbs { get; set; }
        
        public DbSet<DbTable> DbTables { get; set; }
        
        public DbSet<DbField> DbFields { get; set; }
        
        public DbSet<Form> Forms { get; set; }
        
        public DbSet<FormTable> FormTables { get; set; }
        
        public DbSet<FormField> FormFields { get; set; }

        public DbSet<DbSource> DbSources { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FormTable>()
                .HasOne(x => x.Form)
                .WithMany(x => x.FormTables)
                .HasForeignKey(x => x.FormId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}