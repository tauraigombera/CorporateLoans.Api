using EmployeeLoans.Api.Enums;

namespace EmployeeLoans.Api.Dtos.LoanDtos;

public record LoanDto
(
    Guid Id,
    decimal LoanAmount,
    string LoanPurpose,
    DateTime ApplicationDate,
    decimal MonthlyDeductionAmount,
    LoanStatus LoanStatus
);
