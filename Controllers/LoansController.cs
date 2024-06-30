using EmployeeLoans.Api.Dtos;
using EmployeeLoans.Api.Extensions;
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
    public ActionResult<LoanDto> GetLoan(int id)
    {
        var loan = _loanRepository.GetLoan(id).AsDto();

        if (loan is null){
            return NotFound();
        }
        return Ok(loan);
    }

}
