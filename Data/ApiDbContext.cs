using EmployeeLoans.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLoans.Api.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) 
        : base(options)
    {   
    }
    public DbSet<Loan> Loans { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Loan>()
            .Property(d => d.LoanAmount)
            .HasColumnType("decimal(18,2)"); // Adjust precision and scale as per your requirements
    }
}
