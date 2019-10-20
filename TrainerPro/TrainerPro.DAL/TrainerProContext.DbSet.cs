namespace TrainerPro.DAL
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
    }
}
