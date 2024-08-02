using EmployeeLoans.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLoans.Api.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) 
        : base(options)
    {   
    }
    public DbSet<LoanApplication> LoanApplications { get; set; }
    public DbSet<ApprovalHistory> ApprovalHistories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoanApplication>()
            .Property(l => l.LoanAmount)
            .HasColumnType("decimal(18,2)"); // Adjust precision and scale as per your requirements

        modelBuilder.Entity<LoanApplication>()
            .Property(l => l.MonthlyDeductionAmount)
            .HasColumnType("decimal(18,2)"); // Adjust precision and scale as per your requirements

        modelBuilder.Entity<LoanApplication>()
            .Property(l => l.LoanApplicationStatus)
            .HasConversion<string>(); // Store enum as strings

        modelBuilder.Entity<ApprovalHistory>()
            .Property(ah => ah.ApprovalStatus)
            .HasConversion<string>(); // Store enum as strings
    }
}
