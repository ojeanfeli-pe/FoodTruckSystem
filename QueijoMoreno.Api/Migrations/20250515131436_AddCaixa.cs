using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueijoMoreno.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCaixa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaixaId",
                table: "Pedidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Caixas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorInicial = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorFinal = table.Column<decimal>(type: "TEXT", nullable: false),
                    Fechado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_CaixaId",
                table: "Pedidos",
                column: "CaixaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Caixas_CaixaId",
                table: "Pedidos",
                column: "CaixaId",
                principalTable: "Caixas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Caixas_CaixaId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Caixas");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_CaixaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "CaixaId",
                table: "Pedidos");
        }
    }
}
