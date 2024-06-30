using EmployeeLoans.Api.Models;

namespace EmployeeLoans.Api.Repositories;

public interface ILoanRepository
{
    IEnumerable<Loan> GetLoans();
    Loan GetLoan(Guid id);
    void CreateLoan(Loan loan);
}
