using EmployeeLoans.Api.Models;

namespace EmployeeLoans.Api.Reposities;

public class InMemoryLoanRepository : ILoanRepository
{
    //Create a list of loans
    private readonly List<Loan> loans =
    [
        new Loan 
        {
            Id = 1,
            LoanAmount = 1000000,
            LoanPurpose = "Buying a car",
            ApplicationDate = DateTime.Now,
            MonthlyDeduction = 100000
        },
        new Loan 
        {
            Id = 2,
            LoanAmount = 2000000,
            LoanPurpose = "Buying a house",
            ApplicationDate = DateTime.Now,
            MonthlyDeduction = 200000
        },
        new Loan 
        {
            Id = 3,
            LoanAmount = 3000000,
            LoanPurpose = "Buying furniture",
            ApplicationDate = DateTime.Now,
            MonthlyDeduction = 300000
        }
    ];

    //Get loans
    public IEnumerable<Loan> GetLoans()
    {
        return loans;
    }

    //Get a loan by id
    public Loan GetLoan(int id)
    {
        return loans.SingleOrDefault(loan => loan.Id == id)!;
    }

    public void CreateLoan(Loan loan)
    {
        loans.Add(loan);
    }
}
