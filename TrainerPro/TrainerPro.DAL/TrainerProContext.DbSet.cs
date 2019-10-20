namespace TrainerPro.DAL
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Core.Entities;

    /// <summary>
    /// Partial class that contains only DbSets e.g
    /// public DbSet<Test> Tests { get; set; }
    /// </summary>
    public partial class TrainerProContext
    {
        public DbSet<AccountType> AccountTypes { get; set; }
    }
}
