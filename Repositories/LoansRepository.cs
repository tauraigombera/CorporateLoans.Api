using EmployeeLoans.Api.Data;
using EmployeeLoans.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLoans.Api.Repositories;

public class LoansRepository : ILoanApplicationRepository
{
    private readonly ApiDbContext dbContext;

    public LoansRepository(ApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<LoanApplication>> GetLoansAsync()
    {
        return await dbContext.Loans.AsNoTracking().ToListAsync();
    }

    public async Task<LoanApplication?> GetLoanAsync(Guid id)
    {
        return await dbContext.Loans.SingleOrDefaultAsync(loan => loan.Id == id);
    }

    public async Task CreateLoanAsync(LoanApplication loanApplication)
    {
        await dbContext.Loans.AddAsync(loanApplication);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateLoanAsync(LoanApplication loanApplication){
        dbContext.Update(loanApplication);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteLoanAsync(Guid id)
    {
        await dbContext.Loans.Where(loan => loan.Id == id).ExecuteDeleteAsync();
    }
}
