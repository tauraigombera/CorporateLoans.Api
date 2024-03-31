using EmployeeLoans.Api.Models;

namespace EmployeeLoans.Api;

public interface ILoanRepository
{
    IEnumerable<Loan> GetLoans();
    Loan GetLoan(int id);
}
