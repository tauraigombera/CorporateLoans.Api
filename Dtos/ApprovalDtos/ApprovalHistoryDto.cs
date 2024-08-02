using EmployeeLoans.Api.Enums;

namespace EmployeeLoans.Api.Dtos.ApprovalDtos;

public record ApprovalHistoryDto
(
    Guid Id,
    Guid LoanId,
    string ApprovalOffice,
    ApprovalStatus ApprovalStatus,
    string Comment,
    DateTime ApprovalDate
);
