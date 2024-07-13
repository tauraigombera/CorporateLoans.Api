namespace EmployeeLoans.Api.Dtos.LoanDtos;

public record CreateLoanDto
(
    decimal LoanAmount,
    string LoanPurpose,
    decimal MonthlyDeductionAmount
);
