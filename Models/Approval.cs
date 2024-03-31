namespace EmployeeLoans.Api.Models;

public class Approval
{
    public int Id { get; set; }
    public decimal LoanAmount { get; set; }
    public required string LoanPurpose { get; set; }
    public decimal MonthlyDeduction { get; set; }
    public DateTime ApplicationDate { get; set; }
}
