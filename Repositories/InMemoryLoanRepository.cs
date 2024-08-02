using EmployeeLoans.Api.Models;

namespace EmployeeLoans.Api.Repositories;

public class InMemoryLoanRepository : ILoanApplicationRepository
{
    //Create a list of loans
    private readonly List<LoanApplication> loans =
    [
        new LoanApplication
        {
            Id = Guid.NewGuid(),
            LoanAmount = 1000000,
            LoanPurpose = "Buying a car",
            ApplicationDate = DateTime.Now,
            MonthlyDeductionAmount = 100000
        },
        new LoanApplication
        {
            Id = Guid.NewGuid(),
            LoanAmount = 2000000,
            LoanPurpose = "Buying a house",
            ApplicationDate = DateTime.Now,
            MonthlyDeductionAmount = 200000
        },
        new LoanApplication 
        {
            Id = Guid.NewGuid(),
            LoanAmount = 3000000,
            LoanPurpose = "Buying furniture",
            ApplicationDate = DateTime.Now,
            MonthlyDeductionAmount = 300000
        }
    ];

    //Get loans
    public async Task<IEnumerable<LoanApplication>> GetLoansAsync()
    {
        return await Task.FromResult(loans);
    }

    //Get a loan by id
    public async Task<LoanApplication?> GetLoanAsync(Guid id)
    {
        return await Task.FromResult(loans.SingleOrDefault(loan => loan.Id == id));
    }

    public async Task CreateLoanAsync(LoanApplication loanApplication)
    {
        loans.Add(loanApplication);
        await Task.CompletedTask;
    }

    public async Task UpdateLoanAsync(LoanApplication Loan)
    {
        var index = loans.FindIndex(loan => loan.Id == Loan.Id);
        loans[index] = Loan;

        await Task.CompletedTask;
    }

    public async Task DeleteLoanAsync(Guid id)
    {
        var index = loans.FindIndex(loan => loan.Id == id);
        loans.RemoveAt(index);

        await Task.CompletedTask;
    }
}
