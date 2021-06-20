using Microsoft.EntityFrameworkCore.Migrations;

namespace jQueryAjaxInAsp.NETMVC.Migrations
{
    public partial class AddSWIFTCodeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BeneficiaryName",
                table: "Transactions",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "Transactions",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SWIFTCode",
                table: "Transactions",
                type: "nvarchar(11)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SWIFTCode",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "BeneficiaryName",
                table: "Transactions",
                type: "nvarchar(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "Transactions",
                type: "nvarchar(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);
        }
    }
}
