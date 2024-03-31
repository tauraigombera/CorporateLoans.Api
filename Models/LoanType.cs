namespace EmployeeLoans.Api.Models;

public class LoanType
{
    public int Id { get; set; }
    public required string LoanTypeName { get; set; }
    public required string LoanTypeDescription { get; set; }
    public decimal MaxLoanAmount { get; set; }
    public decimal InterestRate { get; set; }
    public required string Collateral { get; set; }
    public int RepaymentPeriod { get; set; } //number of months
}
