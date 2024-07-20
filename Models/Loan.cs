using System.ComponentModel.DataAnnotations;

namespace EmployeeLoans.Api.Models;

public class Loan
{
    public Guid Id { get; set; }
    public decimal LoanAmount { get; set; }
    public required string LoanPurpose { get; set; }
    public DateTime ApplicationDate { get; set; }
    public decimal MonthlyDeductionAmount { get; set; }
    public List<ApprovalHistory>? ApprovalHistories { get; set; }
}
