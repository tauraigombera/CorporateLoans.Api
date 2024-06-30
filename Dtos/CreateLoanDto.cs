namespace EmployeeLoans.Api.Dtos;

public record CreateLoanDto
(
    decimal LoanAmount,
    string LoanPurpose,
    decimal MonthlyDeduction
);
