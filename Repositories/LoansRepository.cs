using EmployeeLoans.Api.Data;
using EmployeeLoans.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLoans.Api.Repositories;

public class LoansRepository : ILoanRepository
{
    private readonly ApiDbContext dbContext;

    public LoansRepository(ApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<Loan> GetLoans()
    {
        return dbContext.Loans.AsNoTracking().ToList();
    }

    public Loan? GetLoan(Guid id)
    {
        return dbContext.Loans.SingleOrDefault(loan => loan.Id == id);
    }

    public void CreateLoan(Loan loan)
    {
        dbContext.Loans.Add(loan);
        dbContext.SaveChanges();
    }

    public void UpdateLoan(Loan loan){
        dbContext.Update(loan);
        dbContext.SaveChanges();
    }

    public void DeleteLoan(Guid id)
    {
        dbContext.Loans.Where(loan => loan.Id == id).ExecuteDelete();
    }
}
