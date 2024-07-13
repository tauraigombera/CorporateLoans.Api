namespace EmployeeLoans.Api.Dtos.LoanDtos;

public record UpdateLoanDto
(
    decimal LoanAmount,
    string LoanPurpose,
    decimal MonthlyDeductionAmount
);
