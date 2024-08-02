using EmployeeLoans.Api.Enums;

namespace EmployeeLoans.Api.Dtos.LoanApplicationDtos;

public record LoanApplicationDto
(
    Guid Id,
    decimal LoanAmount,
    string LoanPurpose,
    DateTime ApplicationDate,
    decimal MonthlyDeductionAmount,
    LoanApplicationStatus LoanApplicationStatus
);
