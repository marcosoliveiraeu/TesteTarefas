using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TarefasApi.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusTarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTarefas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    DtAbertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtConclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefas_StatusTarefas_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusTarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StatusTarefas",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Pendente" },
                    { 2, "Concluída" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_StatusId",
                table: "Tarefas",
                column: "StatusId");

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Id", "Titulo", "Descricao", "StatusId", "DtAbertura", "DtConclusao" },
                values: new object[,]
                {
                    { 1 , "Primeira Tarefa" , "blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla" , 1 , DateTime.Now , null },
                    { 2 , "Segunda Tarefa" , "blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla" , 1 , DateTime.Now , null },
                    { 3 , "Terceira Tarefa" , "blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla" , 2 , DateTime.Now , DateTime.Now },
                    { 4 , "Quarta Tarefa" , "blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla blabla" , 2 , DateTime.Now , DateTime.Now }

                }); ;
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "StatusTarefas");
        }
    }
}
