using EmployeeLoans.Api.Dtos.ApprovalDtos;
using EmployeeLoans.Api.Dtos.LoanDtos;
using EmployeeLoans.Api.Enums;
using EmployeeLoans.Api.Extensions;
using EmployeeLoans.Api.Models;
using EmployeeLoans.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLoans.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoansController : ControllerBase
{
    private readonly ILoanApplicationRepository _loanRepository;

    public LoansController(ILoanApplicationRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    //GET /loans
    [HttpGet]
    public async Task<IEnumerable<LoanApplicationDto>> GetLoans()
    {
        var loans = (await _loanRepository.GetLoansAsync())
                .OrderBy(loan => loan.ApplicationDate)
                .Select(loan => loan.AsDto());
        return loans;
    }

    //GET /loans/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<LoanApplicationDto>> GetLoan(Guid id)
    {
        var loan = await _loanRepository.GetLoanAsync(id);

        if (loan is null){
            return NotFound();
        }
        return loan.AsDto();
    }

    //POST /loans
    [HttpPost]
    public async Task<ActionResult<LoanApplicationDto>> CreateLoans(CreateLoanApplicationDto createLoanDto)
    {
        LoanApplication loan = new(){
            Id = Guid.NewGuid(),
            LoanAmount = createLoanDto.LoanAmount,
            LoanPurpose = createLoanDto.LoanPurpose,
            MonthlyDeductionAmount = createLoanDto.MonthlyDeductionAmount,
            LoanStatus = LoanStatus.Pending, //Default value
            ApplicationDate = DateTime.Now
        };

        await _loanRepository.CreateLoanAsync(loan);
        return CreatedAtAction(nameof(GetLoan), new{id = loan.Id}, loan.AsDto());
    }

    //PUT /loans/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateLoan(Guid id, UpdateLoanApplicationDto updateLoanDto)
    {
        LoanApplication? existingLoan = await _loanRepository.GetLoanAsync(id);

        if (existingLoan is not null)
        {
            existingLoan.LoanAmount = updateLoanDto.LoanAmount;
            existingLoan.LoanPurpose = updateLoanDto.LoanPurpose;
            existingLoan.MonthlyDeductionAmount = updateLoanDto.MonthlyDeductionAmount;

            await _loanRepository.UpdateLoanAsync(existingLoan);

            return NoContent();
        }
        
        return NotFound();
    }


 
    //POST /loans {loanId}/approve
    [HttpPost("{loanId}/approve")]
    public async Task<ActionResult<LoanApplicationDto>> ApproveLoan(Guid loanId, CreateApprovalHistoryDto createApprovalHistoryDto)
    {
        LoanApplication? existingLoan = await _loanRepository.GetLoanAsync(loanId);

        if (existingLoan is not null){
                ApprovalHistory approvalHistory = new(){
                Id = Guid.NewGuid(),
                LoanId = existingLoan.Id,
                ApprovalOffice = createApprovalHistoryDto.ApprovalOffice,
                Comment = createApprovalHistoryDto.Comment,
                ApprovalDate = DateTime.Now
            };
            
            await _loanRepository.ApproveLoanAsync(approvalHistory);
            existingLoan.LoanStatus = LoanStatus.Approved;
            await _loanRepository.UpdateLoanAsync(existingLoan);

            return Ok(existingLoan);
        }
        
        return NotFound();
    }

    //DELETE /organization/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLoan(Guid id)
    {
        LoanApplication? loan = await _loanRepository.GetLoanAsync(id);
        
        if (loan is not null)
        {
           await _loanRepository.DeleteLoanAsync(id);
        } 

        return NoContent();
    }
}
