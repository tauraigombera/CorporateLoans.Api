using EmployeeLoans.Api.Dtos.ApprovalDtos;
using EmployeeLoans.Api.Dtos.LoanApplicationDtos;
using EmployeeLoans.Api.Dtos.LoanDtos;
using EmployeeLoans.Api.Enums;
using EmployeeLoans.Api.Extensions;
using EmployeeLoans.Api.Models;
using EmployeeLoans.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLoans.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoanApplicationsController : ControllerBase
{
    private readonly ILoanApplicationRepository _loanApplicationRepository;

    public LoanApplicationsController(ILoanApplicationRepository loanRepository)
    {
        _loanApplicationRepository = loanRepository;
    }

    //GET /loans
    [HttpGet]
    public async Task<IEnumerable<LoanApplicationDto>> GetLoanApplications()
    {
        var loans = (await _loanApplicationRepository.GetLoansAsync())
                .OrderBy(loan => loan.ApplicationDate)
                .Select(loan => loan.AsDto());
        return loans;
    }

    //GET /loans/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<LoanApplicationDto>> GetLoanApplication(Guid id)
    {
        var loan = await _loanApplicationRepository.GetLoanAsync(id);

        if (loan is null){
            return NotFound();
        }
        return loan.AsDto();
    }

    //POST /loans
    [HttpPost]
    public async Task<ActionResult<LoanApplicationDto>> CreateLoanApplication(CreateLoanApplicationDto createLoanDto)
    {
        LoanApplication loan = new(){
            Id = Guid.NewGuid(),
            LoanAmount = createLoanDto.LoanAmount,
            LoanPurpose = createLoanDto.LoanPurpose,
            MonthlyDeductionAmount = createLoanDto.MonthlyDeductionAmount,
            LoanApplicationStatus = LoanApplicationStatus.Pending, //Default value
            ApplicationDate = DateTime.Now
        };

        await _loanApplicationRepository.CreateLoanAsync(loan);
        return CreatedAtAction(nameof(GetLoanApplication), new{id = loan.Id}, loan.AsDto());
    }

    //PUT /loans/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateLoanApplication(Guid id, UpdateLoanApplicationDto updateLoanDto)
    {
        LoanApplication? existingLoan = await _loanApplicationRepository.GetLoanAsync(id);

        if (existingLoan is not null)
        {
            existingLoan.LoanAmount = updateLoanDto.LoanAmount;
            existingLoan.LoanPurpose = updateLoanDto.LoanPurpose;
            existingLoan.MonthlyDeductionAmount = updateLoanDto.MonthlyDeductionAmount;

            await _loanApplicationRepository.UpdateLoanAsync(existingLoan);

            return NoContent();
        }
        
        return NotFound();
    }


 
    //POST /loans {loanId}/approve
    [HttpPost("{loanId}/approve")]
    public async Task<ActionResult<LoanApplicationDto>> ApproveLoanApplication(Guid loanId, CreateApprovalHistoryDto createApprovalHistoryDto)
    {
        LoanApplication? existingLoan = await _loanApplicationRepository.GetLoanAsync(loanId);

        if (existingLoan is not null){
                ApprovalHistory approvalHistory = new(){
                Id = Guid.NewGuid(),
                LoanApplicationId = existingLoan.Id,
                ApprovalOffice = createApprovalHistoryDto.ApprovalOffice,
                Comment = createApprovalHistoryDto.Comment,
                ApprovalDate = DateTime.Now
            };
            
            await _loanApplicationRepository.ApproveLoanAsync(approvalHistory);
            existingLoan.LoanApplicationStatus = LoanApplicationStatus.Approved;
            await _loanApplicationRepository.UpdateLoanAsync(existingLoan);

            return Ok(existingLoan);
        }
        
        return NotFound();
    }

    //DELETE /organization/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLoanApplication(Guid id)
    {
        LoanApplication? loan = await _loanApplicationRepository.GetLoanAsync(id);
        
        if (loan is not null)
        {
           await _loanApplicationRepository.DeleteLoanAsync(id);
        } 

        return NoContent();
    }
}
