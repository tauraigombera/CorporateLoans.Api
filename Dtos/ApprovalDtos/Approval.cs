namespace EmployeeLoans.Api.Dtos.ApprovalDtos;

public record Approval
(
    Guid Id,
    Guid LoanId,
    string Status,
    string Comment,
    DateTime Date
);
