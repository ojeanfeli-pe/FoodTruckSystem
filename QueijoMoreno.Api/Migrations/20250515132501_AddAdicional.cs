using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueijoMoreno.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAdicional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adicionais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    preco = table.Column<decimal>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adicionais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidoAdicional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemPedidoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdicionalId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidoAdicional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidoAdicional_Adicionais_AdicionalId",
                        column: x => x.AdicionalId,
                        principalTable: "Adicionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensPedidoAdicional_ItensPedido_ItemPedidoId",
                        column: x => x.ItemPedidoId,
                        principalTable: "ItensPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidoAdicional_AdicionalId",
                table: "ItensPedidoAdicional",
                column: "AdicionalId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidoAdicional_ItemPedidoId",
                table: "ItensPedidoAdicional",
                column: "ItemPedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedidoAdicional");

            migrationBuilder.DropTable(
                name: "Adicionais");
        }
    }
}
