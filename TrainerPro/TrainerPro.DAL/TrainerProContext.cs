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

            modelBuilder.Entity<MealProduct>()
                .HasKey(mp => new { mp.ProductId, mp.MealId });

            modelBuilder.Entity<MealProduct>()
                .HasOne(mp => mp.Product)
                .WithMany(p => p.MealProducts)
                .HasForeignKey(mp => mp.ProductId);

            modelBuilder.Entity<MealProduct>()
                .HasOne(mp => mp.Meal)
                .WithMany(m => m.MealProducts)
                .HasForeignKey(mp => mp.MealId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(tp => tp.Trainings)
                .WithOne(u => u.User)
                .HasForeignKey(tp => tp.UserId);

            modelBuilder.Entity<UserMeal>()
                .HasKey(x => new { x.UserId, x.MealId, x.Day, x.MealOfDay });

            modelBuilder.Entity<UserMeal>()
                .HasOne(um => um.User)
                .WithMany(u => u.UserMeals)
                .HasForeignKey(um => um.UserId);

            modelBuilder.Entity<UserMeal>()
                .HasOne(um => um.Meal)
                .WithMany(m => m.UserMeals)
                .HasForeignKey(um => um.MealId);
        }
    }
}
