using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueijoMoreno.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddMotoboy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxasEntregas",
                table: "TaxasEntregas");

            migrationBuilder.RenameTable(
                name: "TaxasEntregas",
                newName: "TaxasEntrega");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxasEntrega",
                table: "TaxasEntrega",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Motoboys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoboys", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motoboys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxasEntrega",
                table: "TaxasEntrega");

            migrationBuilder.RenameTable(
                name: "TaxasEntrega",
                newName: "TaxasEntregas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxasEntregas",
                table: "TaxasEntregas",
                column: "Id");
        }
    }
}
