using EmployeeLoans.Api;
using EmployeeLoans.Api.Data;
using EmployeeLoans.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Registering the Loan repository for dependency injection
builder.Services.AddSingleton<ILoanRepository, InMemoryLoanRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure SQL server connection
var connectionString = builder.Configuration["ConnectionStrings:EmployeeLoansContext"];
builder.Services.AddSqlServer<ApiDbContext>(connectionString);

var app = builder.Build();

// Initializing the database
app.Services.InitializeDbAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
