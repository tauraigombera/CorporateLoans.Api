namespace EmployeeLoans.Api.Models;
public class Approval
{
    public Guid Id { get; set; }
    public required string ApprovalStaus { get; set; }
    public required string Comment   { get; set; }
    public DateTime ApprovalDate { get; set; }
}
