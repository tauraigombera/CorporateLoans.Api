using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeLoans.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLoanStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoanStatus",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanStatus",
                table: "Loans");
        }
    }
}
