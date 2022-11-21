using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStore.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataOcorrencia = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Name" },
                values: new object[] { 1, "Projeto 1" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Name" },
                values: new object[] { 2, "Projeto 2" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "DataOcorrencia", "DataVencimento", "Descricao", "Dono", "ProjectId", "Titulo" },
                values: new object[] { 1, new DateTime(2022, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Victor Baptistella", 1, "Bug #1" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "DataOcorrencia", "DataVencimento", "Descricao", "Dono", "ProjectId", "Titulo" },
                values: new object[] { 2, new DateTime(2022, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Victor Baptistella", 2, "Bug #2" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "DataOcorrencia", "DataVencimento", "Descricao", "Dono", "ProjectId", "Titulo" },
                values: new object[] { 3, new DateTime(2022, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Victor Baptistella", 1, "Bug #3" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectId",
                table: "Tickets",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
