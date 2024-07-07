namespace EmployeeLoans.Api.Dtos;

public record UpdateLoanDto
(
    decimal LoanAmount,
    string LoanPurpose,
    decimal MonthlyDeduction
);
