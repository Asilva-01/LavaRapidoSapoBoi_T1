using Microsoft.EntityFrameworkCore.Migrations;

namespace LavaRapidoSapoBoi.Migrations
{
    public partial class DepartamentoForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Departamento_DepartamentoId",
                table: "Vendas");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Vendas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Departamento_DepartamentoId",
                table: "Vendas",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Departamento_DepartamentoId",
                table: "Vendas");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Vendas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Departamento_DepartamentoId",
                table: "Vendas",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
