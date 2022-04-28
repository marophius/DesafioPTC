using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Endereco_State",
                table: "Proprietarios",
                type: "VARCHAR(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Endereco_State",
                table: "Proprietarios",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(2)",
                oldMaxLength: 2);
        }
    }
}
