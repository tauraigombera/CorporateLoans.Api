namespace EmployeeLoans.Api.Dtos;

public record LoanDto
(
    int Id,
    decimal LoanAmount,
    string LoanPurpose,
    DateTime ApplicationDate,
    decimal MonthlyDeduction
);
