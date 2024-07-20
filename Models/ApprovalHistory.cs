namespace EmployeeLoans.Api.Models;

public class ApprovalHistory
{
    public Guid Id { get; set; }
    public Guid LoanId { get; set; }
    public required string ApprovalOffice { get; set; }
    public required string ApprovalStatus { get; set; } //approved, rejected, pending
    public required string Comment { get; set; }
    public DateTime Date { get; set; }
}