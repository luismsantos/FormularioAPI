using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormularioAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddFormularioPergunta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perguntas_Formularios_FormularioId",
                table: "Perguntas");

            migrationBuilder.DropIndex(
                name: "IX_Perguntas_FormularioId",
                table: "Perguntas");

            migrationBuilder.DropColumn(
                name: "FormularioId",
                table: "Perguntas");

            migrationBuilder.CreateTable(
                name: "FormularioPergunta",
                columns: table => new
                {
                    FormulariosId = table.Column<int>(type: "int", nullable: false),
                    PerguntasPerguntaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioPergunta", x => new { x.FormulariosId, x.PerguntasPerguntaId });
                    table.ForeignKey(
                        name: "FK_FormularioPergunta_Formularios_FormulariosId",
                        column: x => x.FormulariosId,
                        principalTable: "Formularios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormularioPergunta_Perguntas_PerguntasPerguntaId",
                        column: x => x.PerguntasPerguntaId,
                        principalTable: "Perguntas",
                        principalColumn: "PerguntaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioPergunta_PerguntasPerguntaId",
                table: "FormularioPergunta",
                column: "PerguntasPerguntaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormularioPergunta");

            migrationBuilder.AddColumn<int>(
                name: "FormularioId",
                table: "Perguntas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_FormularioId",
                table: "Perguntas",
                column: "FormularioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perguntas_Formularios_FormularioId",
                table: "Perguntas",
                column: "FormularioId",
                principalTable: "Formularios",
                principalColumn: "Id");
        }
    }
}
