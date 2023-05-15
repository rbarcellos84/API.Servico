using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicoInspecao.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LOGIN = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "INSPECAO",
                columns: table => new
                {
                    IdInspecao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CODIGOEMPRESA = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CODIGOCORRETOR = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CODIGOPRODUTO = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NOMEPRODUTO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NUMEROINSPECAO = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECAO", x => x.IdInspecao);
                    table.ForeignKey(
                        name: "FK_INSPECAO_USUARIO_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "USUARIO",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_INSPECAO_IdUsuario",
                table: "INSPECAO",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INSPECAO");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
