using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendDelivery.Migrations
{
    /// <inheritdoc />
    public partial class InserirRestaurantesEAlimentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Carrinhos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Carrinhos",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Local = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Nota = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Preco = table.Column<decimal>(type: "TEXT", nullable: false),
                    Nota = table.Column<double>(type: "REAL", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    FotoUrl = table.Column<string>(type: "TEXT", nullable: true),
                    TempoPreparo = table.Column<int>(type: "INTEGER", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    RestauranteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alimentos_Restaurantes_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_AlimentoId",
                table: "Carrinhos",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_RestauranteId",
                table: "Alimentos",
                column: "RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinhos_Alimentos_AlimentoId",
                table: "Carrinhos",
                column: "AlimentoId",
                principalTable: "Alimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinhos_Alimentos_AlimentoId",
                table: "Carrinhos");

            migrationBuilder.DropTable(
                name: "Alimentos");

            migrationBuilder.DropTable(
                name: "Restaurantes");

            migrationBuilder.DropIndex(
                name: "IX_Carrinhos_AlimentoId",
                table: "Carrinhos");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Carrinhos");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Carrinhos");
        }
    }
}
