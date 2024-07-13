using EmployeeLoans.Api.Dtos.LoanDtos;
using EmployeeLoans.Api.Models;

namespace EmployeeLoans.Api.Extensions;

public static class LoanExtension
{
    public static LoanDto AsDto(this Loan loan)
    {
        return new LoanDto
        (
            loan.Id,
            loan.LoanAmount,
            loan.LoanPurpose,
            loan.ApplicationDate,
            loan.MonthlyDeductionAmount
        );
    }
}
