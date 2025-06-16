using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendDelivery.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarCarrinhoHistorico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhosHistorico_Alimentos_AlimentoId",
                table: "CarrinhosHistorico");

            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhosHistorico_Usuarios_UsuarioId",
                table: "CarrinhosHistorico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhosHistorico",
                table: "CarrinhosHistorico");

            migrationBuilder.RenameTable(
                name: "CarrinhosHistorico",
                newName: "HistoricoCompras");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhosHistorico_UsuarioId",
                table: "HistoricoCompras",
                newName: "IX_HistoricoCompras_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhosHistorico_AlimentoId",
                table: "HistoricoCompras",
                newName: "IX_HistoricoCompras_AlimentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoricoCompras",
                table: "HistoricoCompras",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoCompras_Alimentos_AlimentoId",
                table: "HistoricoCompras",
                column: "AlimentoId",
                principalTable: "Alimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoCompras_Usuarios_UsuarioId",
                table: "HistoricoCompras",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoCompras_Alimentos_AlimentoId",
                table: "HistoricoCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoCompras_Usuarios_UsuarioId",
                table: "HistoricoCompras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoricoCompras",
                table: "HistoricoCompras");

            migrationBuilder.RenameTable(
                name: "HistoricoCompras",
                newName: "CarrinhosHistorico");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricoCompras_UsuarioId",
                table: "CarrinhosHistorico",
                newName: "IX_CarrinhosHistorico_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricoCompras_AlimentoId",
                table: "CarrinhosHistorico",
                newName: "IX_CarrinhosHistorico_AlimentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhosHistorico",
                table: "CarrinhosHistorico",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhosHistorico_Alimentos_AlimentoId",
                table: "CarrinhosHistorico",
                column: "AlimentoId",
                principalTable: "Alimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhosHistorico_Usuarios_UsuarioId",
                table: "CarrinhosHistorico",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
