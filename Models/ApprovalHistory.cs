using EmployeeLoans.Api.Enums;

namespace EmployeeLoans.Api.Models;

public class ApprovalHistory
{
    public Guid Id { get; set; }
    public Guid LoanId { get; set; }
    public required string ApprovalOffice { get; set; }
    public ApprovalStatus ApprovalStatus { get; set; }
    public required string Comment { get; set; }
    public DateTime Date { get; set; }
}