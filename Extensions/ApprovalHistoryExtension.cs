using EmployeeLoans.Api.Dtos.ApprovalDtos;
using EmployeeLoans.Api.Models;

namespace EmployeeLoans.Api.Extensions;

public static class ApprovalHistoryExtension
{
    public static ApprovalHistoryDto AsDto(this ApprovalHistory approvalHistory)
    {
        return new ApprovalHistoryDto
        (
            approvalHistory.Id,
            approvalHistory.LoanId,
            approvalHistory.ApprovalOffice,
            approvalHistory.ApprovalStatus,
            approvalHistory.Comment,
            approvalHistory.ApprovalDate
        );
    }
}
