using EmployeeLoans.Api.Models;

namespace EmployeeLoans.Api.Repositories;

public class InMemoryLoanRepository : ILoanRepository
{
    //Create a list of loans
    private readonly List<Loan> loans =
    [
        new Loan 
        {
            Id = Guid.NewGuid(),
            LoanAmount = 1000000,
            LoanPurpose = "Buying a car",
            ApplicationDate = DateTime.Now,
            MonthlyDeductionAmount = 100000
        },
        new Loan 
        {
            Id = Guid.NewGuid(),
            LoanAmount = 2000000,
            LoanPurpose = "Buying a house",
            ApplicationDate = DateTime.Now,
            MonthlyDeductionAmount = 200000
        },
        new Loan 
        {
            Id = Guid.NewGuid(),
            LoanAmount = 3000000,
            LoanPurpose = "Buying furniture",
            ApplicationDate = DateTime.Now,
            MonthlyDeductionAmount = 300000
        }
    ];

    //Get loans
    public IEnumerable<Loan> GetLoans()
    {
        return loans;
    }

    //Get a loan by id
    public Loan GetLoan(Guid id)
    {
        return loans.SingleOrDefault(loan => loan.Id == id)!;
    }

    public void CreateLoan(Loan loan)
    {
        loans.Add(loan);
    }

    public void UpdateLoan(Loan updatedLoan)
    {
        var index = loans.FindIndex(organization => organization.Id == updatedLoan.Id);
        loans[index] = updatedLoan;
    }

    public void DeleteLoan(Guid id)
    {
        var index = loans.FindIndex(loan => loan.Id == id);
        loans.RemoveAt(index);
    }
}
