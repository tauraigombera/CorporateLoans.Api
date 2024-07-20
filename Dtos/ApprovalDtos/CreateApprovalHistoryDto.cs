using EmployeeLoans.Api.Enums;

namespace EmployeeLoans.Api.Dtos.ApprovalDtos;

public record CreateApprovalHistoryDto
(
    Guid LoanId,
    string ApprovalOffice,
    ApprovalStatus ApprovalStatus,
    string Comment,
    DateTime Date
);