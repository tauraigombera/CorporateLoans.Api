using EmployeeLoans.Api.Enums;

namespace EmployeeLoans.Api.Dtos.ApprovalDtos;

public record Approval
(
    Guid Id,
    Guid LoanId,
    string ApprovalOffice,
    LoanStatus LoanStatus,
    string Comment,
    DateTime Date
);
