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

    public async Task<IEnumerable<Loan>> GetLoansAsync()
    {
        return await dbContext.Loans.AsNoTracking().ToListAsync();
    }

    public async Task<Loan?> GetLoanAsync(Guid id)
    {
        return await dbContext.Loans.SingleOrDefaultAsync(loan => loan.Id == id);
    }

    public async Task CreateLoanAsync(Loan loan)
    {
        await dbContext.Loans.AddAsync(loan);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateLoanAsync(Loan loan){
        dbContext.Update(loan);
        await dbContext.SaveChangesAsync();
    }

    public async Task ApproveLoanAsync(ApprovalHistory approvalHistory)
    {
        await dbContext.ApprovalHistories.AddAsync(approvalHistory);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteLoanAsync(Guid id)
    {
        await dbContext.Loans.Where(loan => loan.Id == id).ExecuteDeleteAsync();
    }
}
