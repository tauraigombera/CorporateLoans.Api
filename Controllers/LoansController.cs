using EmployeeLoans.Api.Dtos.LoanDtos;
using EmployeeLoans.Api.Extensions;
using EmployeeLoans.Api.Models;
using EmployeeLoans.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLoans.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoansController : ControllerBase
{
    private readonly ILoanRepository _loanRepository;

    public LoansController(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    //GET /loans
    [HttpGet]
    public async Task<IEnumerable<LoanDto>> GetLoans()
    {
        var loans = (await _loanRepository.GetLoansAsync()).Select(loan => loan.AsDto());
        return loans;
    }

    //GET /loans/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<LoanDto>> GetLoan(Guid id)
    {
        var loan = await _loanRepository.GetLoanAsync(id);

        if (loan is null){
            return NotFound();
        }
        return loan.AsDto();
    }

    //POST /loans
    [HttpPost]
    public async Task<ActionResult<LoanDto>> CreateLoans(CreateLoanDto createLoanDto)
    {
        Loan loan = new(){
            Id = Guid.NewGuid(),
            LoanAmount = createLoanDto.LoanAmount,
            LoanPurpose = createLoanDto.LoanPurpose,
            MonthlyDeductionAmount = createLoanDto.MonthlyDeductionAmount,
            ApplicationDate = DateTime.Now
        };

        await _loanRepository.CreateLoanAsync(loan);
        return CreatedAtAction(nameof(GetLoan), new{id = loan.Id}, loan.AsDto());
    }

    //PUT /loans/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateLoan(Guid id, UpdateLoanDto updateLoanDto)
    {
        Loan? existingLoan = await _loanRepository.GetLoanAsync(id);

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

    //DELETE /organization/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLoan(Guid id)
    {
        Loan? loan = await _loanRepository.GetLoanAsync(id);
        
        if (loan is not null)
        {
           await _loanRepository.DeleteLoanAsync(id);
        } 

        return NoContent();
    }
}
