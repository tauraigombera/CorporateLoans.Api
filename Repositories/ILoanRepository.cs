using EmployeeLoans.Api.Models;

namespace EmployeeLoans.Api.Repositories;

public interface ILoanRepository
{
    Task<IEnumerable<Loan>> GetLoansAsync();
    Task<Loan?> GetLoanAsync(Guid id);
    Task CreateLoanAsync(Loan loan);
    Task UpdateLoanAsync(Loan loan);
    Task ApproveLoanAsync(ApprovalHistory approvalHistory);
    Task DeleteLoanAsync(Guid id);
}

