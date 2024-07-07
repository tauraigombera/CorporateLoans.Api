﻿using EmployeeLoans.Api.Dtos;
using EmployeeLoans.Api.Extensions;
using EmployeeLoans.Api.Models;
using EmployeeLoans.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLoans.Api.Controllers;

[ApiController]
[Route("loans")]
public class LoansController : ControllerBase
{
    private readonly ILoanRepository _loanRepository;

    public LoansController(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    //GET /loans
    [HttpGet]
    public IEnumerable<LoanDto> GetLoans()
    {
        var loans = _loanRepository.GetLoans().Select(loan => loan.AsDto());
        return loans;
    }

    //GET /loans/{id}
    [HttpGet("{id}")]
    public ActionResult<LoanDto> GetLoan(Guid id)
    {
        var loan = _loanRepository.GetLoan(id);

        if (loan is null){
            return NotFound();
        }
        return loan.AsDto();
    }

    //POST /loans
    [HttpPost]
    public ActionResult<LoanDto> CreateLoans(CreateLoanDto createLoanDto)
    {
        Loan loan = new(){
            Id = Guid.NewGuid(),
            LoanAmount = createLoanDto.LoanAmount,
            LoanPurpose = createLoanDto.LoanPurpose,
            MonthlyDeductionAmount = createLoanDto.MonthlyDeduction,
            ApplicationDate = DateTime.Now
        };

        _loanRepository.CreateLoan(loan);
        return CreatedAtAction(nameof(GetLoan), new{id = loan.Id}, loan.AsDto());
    }

    //PUT /loans/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateLoan(Guid id, UpdateLoanDto updateLoanDto)
    {
        Loan? existingLoan = _loanRepository.GetLoan(id);

        if (existingLoan is not null)
        {
            existingLoan.LoanAmount = updateLoanDto.LoanAmount;
            existingLoan.LoanPurpose = updateLoanDto.LoanPurpose;
            existingLoan.MonthlyDeductionAmount = updateLoanDto.MonthlyDeductionAmount;

            _loanRepository.UpdateLoan(existingLoan);

            return NoContent();
        }
        
        return NotFound();
    }

    //DELETE /organization/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteLoan(Guid id)
    {
        Loan? loan = _loanRepository.GetLoan(id);
        
        if (loan is not null)
        {
            _loanRepository.DeleteLoan(id);
        } 

        return NoContent();
    }
}
