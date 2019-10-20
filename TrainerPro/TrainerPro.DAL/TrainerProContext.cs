namespace TrainerPro.DAL
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TrainerPro.Core.Identities;

    /// <summary>
    /// Partial class that contains EF DbContext configuration
    /// </summary>
    public partial class TrainerProContext : IdentityDbContext<ApplicationUser, IdentityRole<string>, string>
    {
        public TrainerProContext(DbContextOptions<TrainerProContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.AccountType)
                .WithMany(t => t.ApplicationUsers)
                .HasForeignKey(u => u.AccountTypeId);
        }
    }
}
