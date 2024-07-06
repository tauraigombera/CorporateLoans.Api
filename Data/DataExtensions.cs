using Microsoft.EntityFrameworkCore;

namespace EmployeeLoans.Api.Data;

public static class DataExtensions
{
    public static void InitializeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
        dbContext.Database.Migrate();
    }
}


