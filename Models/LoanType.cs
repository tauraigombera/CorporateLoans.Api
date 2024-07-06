using System.ComponentModel.DataAnnotations;

namespace EmployeeLoans.Api.Models;

public class LoanType
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string LoanTypeName { get; set; }
    [Required]
    [StringLength(100)]
    public required string LoanTypeDescription { get; set; }
    [Required]
    public decimal MaxLoanAmount { get; set; }
    [Required]
    public decimal InterestRate { get; set; }
    [Required]
    [StringLength(50)]
    public required string Collateral { get; set; }
    [Required]
    public int RepaymentPeriod { get; set; } //number of months
}
