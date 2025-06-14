using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendDelivery.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaCartaoComCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CVV",
                table: "Cartoes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Validade",
                table: "Cartoes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV",
                table: "Cartoes");

            migrationBuilder.DropColumn(
                name: "Validade",
                table: "Cartoes");
        }
    }
}
