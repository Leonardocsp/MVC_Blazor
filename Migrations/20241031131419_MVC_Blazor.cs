using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Blazor.Migrations
{
    /// <inheritdoc />
    public partial class MVC_Blazor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    ID_Curso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Curso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carga_Horaria = table.Column<int>(type: "int", nullable: false),
                    Data_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.ID_Curso);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios1",
                columns: table => new
                {
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_Criacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios1", x => x.ID_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "Inscricoes",
                columns: table => new
                {
                    ID_Inscricao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_Inscricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    ID_Curso = table.Column<int>(type: "int", nullable: false),
                    Status_Inscricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nota_Final = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Data_Conclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioID_Usuario = table.Column<int>(type: "int", nullable: true),
                    CursoID_Curso = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscricoes", x => x.ID_Inscricao);
                    table.ForeignKey(
                        name: "FK_Inscricoes_Cursos_CursoID_Curso",
                        column: x => x.CursoID_Curso,
                        principalTable: "Cursos",
                        principalColumn: "ID_Curso");
                    table.ForeignKey(
                        name: "FK_Inscricoes_Usuarios1_UsuarioID_Usuario",
                        column: x => x.UsuarioID_Usuario,
                        principalTable: "Usuarios1",
                        principalColumn: "ID_Usuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscricoes_CursoID_Curso",
                table: "Inscricoes",
                column: "CursoID_Curso");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricoes_UsuarioID_Usuario",
                table: "Inscricoes",
                column: "UsuarioID_Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscricoes");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Usuarios1");
        }
    }
}
