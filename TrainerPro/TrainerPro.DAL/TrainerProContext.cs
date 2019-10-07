namespace TrainerPro.DAL
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Partial class that contains EF DbContext configuration
    /// </summary>
    public partial class TrainerProContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
