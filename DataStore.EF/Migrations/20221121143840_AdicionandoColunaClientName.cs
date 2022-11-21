using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStore.EF.Migrations
{
    public partial class AdicionandoColunaClientName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Projects",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Projects");
        }
    }
}
