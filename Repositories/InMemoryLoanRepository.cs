// using EmployeeLoans.Api.Models;

// namespace EmployeeLoans.Api.Repositories;

// public class InMemoryLoanRepository : ILoanRepository
// {
//     //Create a list of loans
//     private readonly List<Loan> loans =
//     [
//         new Loan 
//         {
//             Id = Guid.NewGuid(),
//             LoanAmount = 1000000,
//             LoanPurpose = "Buying a car",
//             ApplicationDate = DateTime.Now,
//             MonthlyDeductionAmount = 100000
//         },
//         new Loan 
//         {
//             Id = Guid.NewGuid(),
//             LoanAmount = 2000000,
//             LoanPurpose = "Buying a house",
//             ApplicationDate = DateTime.Now,
//             MonthlyDeductionAmount = 200000
//         },
//         new Loan 
//         {
//             Id = Guid.NewGuid(),
//             LoanAmount = 3000000,
//             LoanPurpose = "Buying furniture",
//             ApplicationDate = DateTime.Now,
//             MonthlyDeductionAmount = 300000
//         }
//     ];

//     //Get loans
//     public async Task<IEnumerable<Loan>> GetLoansAsync()
//     {
//         return await Task.FromResult(loans);
//     }

//     //Get a loan by id
//     public async Task<Loan?> GetLoanAsync(Guid id)
//     {
//         return await Task.FromResult(loans.SingleOrDefault(loan => loan.Id == id));
//     }

//     public async Task CreateLoanAsync(Loan loan)
//     {
//         loans.Add(loan);
//         await Task.CompletedTask;
//     }

//     public async Task UpdateLoanAsync(Loan Loan)
//     {
//         var index = loans.FindIndex(loan => loan.Id == Loan.Id);
//         loans[index] = Loan;

//         await Task.CompletedTask;
//     }

//     public async Task DeleteLoanAsync(Guid id)
//     {
//         var index = loans.FindIndex(loan => loan.Id == id);
//         loans.RemoveAt(index);

//         await Task.CompletedTask;
//     }
// }
