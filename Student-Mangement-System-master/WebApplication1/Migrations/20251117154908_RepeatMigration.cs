using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class RepeatMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "IdCard",
                table: "Employees",
                newName: "Idcard");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Idcard",
                table: "Employees",
                newName: "IdCard");

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
