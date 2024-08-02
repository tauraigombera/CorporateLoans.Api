namespace EmployeeLoans.Api.Dtos.LoanDtos;

public record UpdateLoanApplicationDto
(
    decimal LoanAmount,
    string LoanPurpose,
    decimal MonthlyDeductionAmount
);
