using System.ComponentModel.DataAnnotations;

namespace EmployeeLoans.Api.Models;

public class Loan
{
    public Guid Id { get; set; }
    [Required]
    public decimal LoanAmount { get; set; }
    [Required]
    [StringLength(250)]
    public required string LoanPurpose { get; set; }
    [Required]
    public DateTime ApplicationDate { get; set; }
    [Required]
    public decimal MonthlyDeductionAmount { get; set; }
}
