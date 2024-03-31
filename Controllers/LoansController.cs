using EmployeeLoans.Api.Models;
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
    public IEnumerable<Loan> GetLoans()
    {
        var loans = _loanRepository.GetLoans();
        return loans;
    }

    //GET /loans/{id}
    [HttpGet("{id}")]
    public ActionResult<Loan> GetLoan(int id)
    {
        var loan = _loanRepository.GetLoan(id);

        if (loan is null){
            return NotFound();
        }
        return Ok(loan);
    }

}
