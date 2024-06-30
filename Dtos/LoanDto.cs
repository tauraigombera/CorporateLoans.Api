namespace EmployeeLoans.Api.Dtos;

public record LoanDto
(
    decimal LoanAmount,
    string LoanPurpose,
    DateTime ApplicationDate,
    decimal MonthlyDeduction
);
