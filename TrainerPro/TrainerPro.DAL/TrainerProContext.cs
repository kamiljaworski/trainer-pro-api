namespace TrainerPro.DAL
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using TrainerPro.Core.Entities;
    using TrainerPro.Core.Identities;

    /// <summary>
    /// Partial class that contains EF DbContext configuration
    /// </summary>
    public partial class TrainerProContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public TrainerProContext(DbContextOptions<TrainerProContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.AccountType)
                .WithMany(t => t.ApplicationUsers)
                .HasForeignKey(u => u.AccountTypeId);

            modelBuilder.Entity<AccountType>()
                .HasData(new AccountType { Id = 1, Name = "Client", Description = "Klient" },
                         new AccountType { Id = 2, Name = "Trainer", Description = "Trener" });
        }
    }
}
