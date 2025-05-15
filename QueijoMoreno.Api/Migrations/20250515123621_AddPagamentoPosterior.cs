using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueijoMoreno.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPagamentoPosterior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PagarDepois",
                table: "Pedidos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pago",
                table: "Pedidos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Motoboys",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PagarDepois",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Pago",
                table: "Pedidos");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Motoboys",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");
        }
    }
}
