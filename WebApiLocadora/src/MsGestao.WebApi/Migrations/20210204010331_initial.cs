using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Locadora.WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.Sql(" SET IDENTITY_INSERT AspNetUserClaims ON ");
            migrationBuilder.Sql(" INSERT AspNetUsers(Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES(N'4df27fb6-713b-401e-b9aa-cd794f71f0f3', N'administrador@maissoftwares.com.br', N'ADMINISTRADOR@MAISSOFTWARES.COM.BR', N'administrador@maissoftwares.com.br', N'ADMINISTRADOR@MAISSOFTWARES.COM.BR', 1, N'AQAAAAEAACcQAAAAEN7m7pq0N2vNpeWu775AWIY+eFFn996hvtfU13LTkv5fxuhBlKSgBDjsZftbXErLNw==', N'5IFZ5TUBAHVNFKWZGLCP3QCNYNILODN7', N'4551c9d6-14c8-4a26-8ce1-fea62590c0f7', NULL, 0, 0, NULL, 1, 0) ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7669, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_visualizar')				");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7670, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_buscaavancada')			");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7671, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_adicionar')				");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7672, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_editar')              		");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7673, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_excluir')					");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7674, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_enviarpagamento')			");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7675, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_cancelarpagamento')		");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7676, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_efetuarpagamento')			");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7677, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_estornarpagamento')		");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7678, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_produzirpedido')			");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7679, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_concluirproducao')         ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7680, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_cancelarproducao')         ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7681, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_liberarentrega')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7682, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_concluirentrega')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7683, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_cancelarentrega')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7684, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_finalizarpedido')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7685, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_imprimirviaproducao')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7686, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_imprimirresumomateriais')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7687, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_imprimirorcamento')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7688, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7689, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'venda', 'venda_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7690, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_cliente', 'cad_cliente_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7691, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_cliente', 'cad_cliente_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7692, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_cliente', 'cad_cliente_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7693, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_cliente', 'cad_cliente_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7694, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_cliente', 'cad_cliente_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7695, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_cliente', 'cad_cliente_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7696, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_fornecedor', 'cad_fornecedor_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7697, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_fornecedor', 'cad_fornecedor_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7698, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_fornecedor', 'cad_fornecedor_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7699, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_fornecedor', 'cad_fornecedor_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7700, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_fornecedor', 'cad_fornecedor_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7701, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_fornecedor', 'cad_fornecedor_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7702, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_funcionario', 'cad_funcionario_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7703, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_funcionario', 'cad_funcionario_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7704, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_funcionario', 'cad_funcionario_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7705, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_funcionario', 'cad_funcionario_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7706, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_funcionario', 'cad_funcionario_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7707, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_funcionario', 'cad_funcionario_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7708, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_empreendimento', 'cad_empreendimento_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7709, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_empreendimento', 'cad_empreendimento_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7710, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_empreendimento', 'cad_empreendimento_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7711, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_empreendimento', 'cad_empreendimento_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7712, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_empreendimento', 'cad_empreendimento_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7713, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_empreendimento', 'cad_empreendimento_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7714, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_quadra', 'cad_quadra_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7715, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_quadra', 'cad_quadra_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7716, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_quadra', 'cad_quadra_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7717, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_quadra', 'cad_quadra_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7718, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_quadra', 'cad_quadra_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7719, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_quadra', 'cad_quadra_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7720, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_unidade', 'cad_unidade_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7721, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_unidade', 'cad_unidade_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7722, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_unidade', 'cad_unidade_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7723, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_unidade', 'cad_unidade_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7724, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_unidade', 'cad_unidade_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7725, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_unidade', 'cad_unidade_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7726, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_vendaunidade', 'cad_vendaunidade_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7727, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_vendaunidade', 'cad_vendaunidade_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7728, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_vendaunidade', 'cad_vendaunidade_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7729, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_vendaunidade', 'cad_vendaunidade_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7730, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_vendaunidade', 'cad_vendaunidade_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7731, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_vendaunidade', 'cad_vendaunidade_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7732, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_indice_correcao_monetaria_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7733, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_indice_correcao_monetaria_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7734, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_indice_correcao_monetaria_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7735, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_indice_correcao_monetaria_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7736, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_indice_correcao_monetaria_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7737, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_indice_correcao_monetaria_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7738, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_cotacao_indice_correcao_monetaria_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7739, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_cotacao_indice_correcao_monetaria_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7740, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_cotacao_indice_correcao_monetaria_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7741, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_cotacao_indice_correcao_monetaria_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7742, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_cotacao_indice_correcao_monetaria_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7743, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_cotacao_indice_correcao_monetaria_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7744, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_indice_reajuste_contrato_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7745, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_indice_reajuste_contrato_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7746, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_indice_reajuste_contrato_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7747, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_indice_reajuste_contrato_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7748, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_indice_reajuste_contrato_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7749, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cad_indice_correcao_monetaria', 'cad_indice_reajuste_contrato_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7750, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_planosdeconta', 'fin_planosdeconta_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7751, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_planosdeconta', 'fin_planosdeconta_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7752, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_planosdeconta', 'fin_planosdeconta_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7753, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_planosdeconta', 'fin_planosdeconta_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7754, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_planosdeconta', 'fin_planosdeconta_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7755, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_planosdeconta', 'fin_planosdeconta_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7756, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_centrosdecusto', 'fin_centrosdecusto_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7757, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_centrosdecusto', 'fin_centrosdecusto_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7758, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_centrosdecusto', 'fin_centrosdecusto_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7759, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_centrosdecusto', 'fin_centrosdecusto_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7760, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_centrosdecusto', 'fin_centrosdecusto_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7761, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_centrosdecusto', 'fin_centrosdecusto_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7762, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_formasdepagamento', 'fin_formasdepagamento_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7763, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_formasdepagamento', 'fin_formasdepagamento_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7764, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_formasdepagamento', 'fin_formasdepagamento_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7765, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_formasdepagamento', 'fin_formasdepagamento_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7766, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_formasdepagamento', 'fin_formasdepagamento_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7767, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_formasdepagamento', 'fin_formasdepagamento_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7768, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_contabancaria', 'fin_contabancaria_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7769, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_contabancaria', 'fin_contabancaria_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7770, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_contabancaria', 'fin_contabancaria_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7771, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_contabancaria', 'fin_contabancaria_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7772, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_contabancaria', 'fin_contabancaria_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7773, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_contabancaria', 'fin_contabancaria_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7774, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_lancamentos', 'fin_lancamentos_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7775, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_lancamentos', 'fin_lancamentos_buscaavancada')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7776, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_lancamentos', 'fin_lancamentos_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7777, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_lancamentos', 'fin_lancamentos_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7778, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_lancamentos', 'fin_lancamentos_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7779, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_lancamentos', 'fin_lancamentos_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7780, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_lancamentos', 'fin_lancamentos_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7781, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_lancamentos', 'fin_lancamentos_quitar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7782, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'fin_lancamentos', 'fin_lancamentos_estornar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7783, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'est_gruposdeproduto', 'est_gruposdeproduto_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7784, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'est_gruposdeproduto', 'est_gruposdeproduto_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7785, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'est_gruposdeproduto', 'est_gruposdeproduto_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7786, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'est_gruposdeproduto', 'est_gruposdeproduto_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7787, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'est_gruposdeproduto', 'est_gruposdeproduto_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7788, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'est_gruposdeproduto', 'est_gruposdeproduto_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7789, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'est_produtos', 'est_produtos_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7790, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'est_produtos', 'est_produtos_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7791, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'est_produtos', 'est_produtos_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7792, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'est_produtos', 'est_produtos_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7793, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'est_produtos', 'est_produtos_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7794, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'est_produtos', 'est_produtos_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7795, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'aux_tiposdecontato', 'aux_tiposdecontato_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7796, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'aux_tiposdecontato', 'aux_tiposdecontato_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7797, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'aux_tiposdecontato', 'aux_tiposdecontato_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7798, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'aux_tiposdecontato', 'aux_tiposdecontato_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7799, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'aux_tiposdecontato', 'aux_tiposdecontato_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7800, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'aux_tiposdecontato', 'aux_tiposdecontato_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7801, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'aux_tiposdeendereco', 'aux_tiposdeendereco_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7802, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'aux_tiposdeendereco', 'aux_tiposdeendereco_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7803, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'aux_tiposdeendereco', 'aux_tiposdeendereco_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7804, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'aux_tiposdeendereco', 'aux_tiposdeendereco_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7805, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'aux_tiposdeendereco', 'aux_tiposdeendereco_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7806, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'aux_tiposdeendereco', 'aux_tiposdeendereco_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7807, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cfg_usuarios', 'cfg_usuarios_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7808, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cfg_usuarios', 'cfg_usuarios_adicionar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7809, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cfg_usuarios', 'cfg_usuarios_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7810, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cfg_usuarios', 'cfg_usuarios_excluir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7811, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cfg_usuarios', 'cfg_usuarios_exportar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7812, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cfg_usuarios', 'cfg_usuarios_imprimir')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7813, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cfg_dadosdaempresa', 'cfg_dadosdaempresa_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7814, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cfg_dadosdaempresa', 'cfg_dadosdaempresa_editar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7815, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cfg_configuracoesgerais', 'cfg_configuracoesgerais_visualizar')                          ");
            migrationBuilder.Sql(" INSERT AspNetUserClaims (Id, UserId, ClaimType, ClaimValue) VALUES (7816, '4df27fb6-713b-401e-b9aa-cd794f71f0f3', 'cfg_configuracoesgerais', 'cfg_configuracoesgerais_editar')                          ");
            migrationBuilder.Sql(" SET IDENTITY_INSERT AspNetUserClaims OFF ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(" DELETE FROM AspNetUserClaims WHERE UserId = '4df27fb6-713b-401e-b9aa-cd794f71f0f3' ");
            migrationBuilder.Sql(" DELETE FROM AspNetUsers WHERE Id = '4df27fb6-713b-401e-b9aa-cd794f71f0f3' ");
            
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
