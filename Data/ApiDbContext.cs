using EmployeeLoans.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLoans.Api.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) 
        : base(options)
    {   
    }
    public DbSet<LoanApplication> Loans { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoanApplication>()
            .Property(l => l.LoanAmount)
            .HasColumnType("decimal(18,2)"); // Adjust precision and scale as per your requirements

            modelBuilder.Entity<LoanApplication>()
            .Property(l => l.MonthlyDeductionAmount)
            .HasColumnType("decimal(18,2)"); // Adjust precision and scale as per your requirements
    }
}
