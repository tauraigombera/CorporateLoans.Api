using EmployeeLoans.Api.Dtos.LoanDtos;
using EmployeeLoans.Api.Models;

namespace EmployeeLoans.Api.Extensions;

public static class LoanExtension
{
    public static LoanApplicationDto AsDto(this LoanApplication loanApplication)
    {
        return new LoanApplicationDto
        (
            loanApplication.Id,
            loanApplication.LoanAmount,
            loanApplication.LoanPurpose,
            loanApplication.ApplicationDate,
            loanApplication.MonthlyDeductionAmount
        );
    }
}
