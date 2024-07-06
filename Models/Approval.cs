using System.ComponentModel.DataAnnotations;

namespace EmployeeLoans.Api.Models;

public class Approval
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string ApprovalStaus { get; set; }
    [Required]
    [StringLength(250)]
    public required string Comment   { get; set; }
    [Required]
    public DateTime ApprovalDate { get; set; }
}
