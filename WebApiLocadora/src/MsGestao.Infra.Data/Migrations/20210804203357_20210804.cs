using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Infra.Data.Migrations
{
    public partial class _20210804 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "SequencialNumeroDaReserva");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataLiberacao = table.Column<DateTime>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Midias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Multa = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Midias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    DataLancamento = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    QuantidadeDisponivel = table.Column<int>(nullable: false),
                    MidiaId = table.Column<int>(nullable: false),
                    MidiaId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Midias_MidiaId1",
                        column: x => x.MidiaId1,
                        principalTable: "Midias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemsLocacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    LocacaoId = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsLocacao_Locacoes_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "Locacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsLocacao_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsLocacao_LocacaoId",
                table: "ItemsLocacao",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsLocacao_ProdutoId",
                table: "ItemsLocacao",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_MidiaId1",
                table: "Produtos",
                column: "MidiaId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsLocacao");

            migrationBuilder.DropTable(
                name: "Locacoes");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Midias");

            migrationBuilder.CreateSequence<int>(
                name: "SequencialNumeroDaReserva",
                startValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100);
        }
    }
}
