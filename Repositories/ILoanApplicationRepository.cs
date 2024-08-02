using EmployeeLoans.Api.Models;

namespace EmployeeLoans.Api.Repositories;

public interface ILoanApplicationRepository
{
    Task<IEnumerable<LoanApplication>> GetLoansAsync();

    Task<LoanApplication?> GetLoanAsync(Guid id);

    Task CreateLoanAsync(LoanApplication loanApplication);

    Task UpdateLoanAsync(LoanApplication loanApplication);

    Task DeleteLoanAsync(Guid id);
}
