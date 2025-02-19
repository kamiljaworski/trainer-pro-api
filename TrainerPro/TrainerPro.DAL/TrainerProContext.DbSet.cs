﻿namespace TrainerPro.DAL
{
    using Core.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Partial class that contains only DbSets e.g
    /// public DbSet<Test> Tests { get; set; }
    /// </summary>
    public partial class TrainerProContext
    {
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealProduct> MealProducts { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<UserMeal> UserMeals { get; set; }
    }
}
