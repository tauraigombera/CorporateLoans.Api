namespace EmployeeLoans.Api.Dtos;

public record LoanDto
(
    Guid Id,
    decimal LoanAmount,
    string LoanPurpose,
    DateTime ApplicationDate,
    decimal MonthlyDeduction
);
