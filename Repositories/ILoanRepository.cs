using EmployeeLoans.Api.Models;

namespace EmployeeLoans.Api;

public interface ILoanRepository
{
    IEnumerable<Loan> GetLoans();
    Loan GetLoan(Guid id);
    void CreateLoan(Loan loan);
}
