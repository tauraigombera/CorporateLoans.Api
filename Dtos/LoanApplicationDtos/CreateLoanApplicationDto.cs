namespace EmployeeLoans.Api.Dtos.LoanDtos;

public record CreateLoanApplicationDto
(
    decimal LoanAmount,
    string LoanPurpose,
    decimal MonthlyDeductionAmount
);
