using Microsoft.EntityFrameworkCore;
using TravelClaimsAppBackend.Models;

namespace TravelClaimsAppBackend.Data
{
    public class TravelClaimsDbContext: DbContext
    {
        public TravelClaimsDbContext(DbContextOptions<TravelClaimsDbContext> options) : base(options)
        {
        }

        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<ExpenseSubtype> ExpenseSubtypes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<SubExpense> SubExpenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .HasKey(e => new { e.ExpenseId });

            modelBuilder.Entity<SubExpense>()
                .HasOne(se => se.Expense)
                .WithMany()
                .HasForeignKey(se => new {se.ExpenseId});

            modelBuilder.Entity<Expense>()
                .HasOne<ExpenseType>()
                .WithMany()
                .HasForeignKey(e => e.ExpenseTypeId)
                .OnDelete(DeleteBehavior.Cascade); // This enables cascade delete for ExpenseType

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Expenses)
                .WithOne()
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(DeleteBehavior.Cascade); // This already exists for Project
        }

    }
}
