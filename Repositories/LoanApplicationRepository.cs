using EmployeeLoans.Api.Data;
using EmployeeLoans.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLoans.Api.Repositories;

public class LoanApplicationRepository : ILoanApplicationRepository
{
    private readonly ApiDbContext dbContext;

    public LoanApplicationRepository(ApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<LoanApplication>> GetLoansAsync()
    {
        return await dbContext.LoanApplications.AsNoTracking().ToListAsync();
    }

    public async Task<LoanApplication?> GetLoanAsync(Guid id)
    {
        return await dbContext.LoanApplications.SingleOrDefaultAsync(loan => loan.Id == id);
    }

    public async Task CreateLoanAsync(LoanApplication loanApplication)
    {
        await dbContext.LoanApplications.AddAsync(loanApplication);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateLoanAsync(LoanApplication loanApplication){
        dbContext.Update(loanApplication);
        await dbContext.SaveChangesAsync();
    }

    public async Task ApproveLoanAsync(ApprovalHistory approvalHistory)
    {
        await dbContext.ApprovalHistories.AddAsync(approvalHistory);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteLoanAsync(Guid id)
    {
        await dbContext.LoanApplications.Where(loan => loan.Id == id).ExecuteDeleteAsync();
    }
}
