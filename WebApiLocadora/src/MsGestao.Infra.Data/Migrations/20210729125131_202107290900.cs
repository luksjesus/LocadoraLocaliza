using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Infra.Data.Migrations
{
    public partial class _202107290900 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "SequencialNumeroDaReserva",
                startValue: 0L);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Cep = table.Column<string>(maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 100, nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Cidade = table.Column<string>(maxLength: 100, nullable: false),
                    Estado = table.Column<string>(maxLength: 2, nullable: false),
                    Complemento = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropSequence(
                name: "SequencialNumeroDaReserva");
        }
    }
}
