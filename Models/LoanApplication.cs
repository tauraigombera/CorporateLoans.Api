using EmployeeLoans.Api.Enums;

namespace EmployeeLoans.Api.Models;

public class LoanApplication
{
    public Guid Id { get; set; }
    public decimal LoanAmount { get; set; }
    public required string LoanPurpose { get; set; }
    public DateTime ApplicationDate { get; set; }
    public decimal MonthlyDeductionAmount { get; set; }
    public LoanStatus LoanApplicationStatus { get; set; }
    public List<ApprovalHistory>? ApprovalHistories { get; set; }
}
