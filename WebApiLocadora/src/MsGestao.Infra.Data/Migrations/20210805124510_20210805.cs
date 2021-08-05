using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Infra.Data.Migrations
{
    public partial class _20210805 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Locacoes");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDeProduto",
                table: "Produtos",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StatusDaVenda",
                table: "Locacoes",
                nullable: false,
                defaultValue: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusDaVenda",
                table: "Locacoes");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDeProduto",
                table: "Produtos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Locacoes",
                type: "int",
                nullable: false,
                defaultValue: 10);
        }
    }
}
