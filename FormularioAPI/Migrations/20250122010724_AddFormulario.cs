using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormularioAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddFormulario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Perguntas_PerguntaId",
                table: "Respostas");

            migrationBuilder.AlterColumn<int>(
                name: "PerguntaId",
                table: "Respostas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FormularioId",
                table: "Perguntas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Formularios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formularios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Perguntas_PerguntaId",
                table: "Respostas",
                column: "PerguntaId",
                principalTable: "Perguntas",
                principalColumn: "PerguntaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perguntas_Formularios_FormularioId",
                table: "Perguntas");

            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Perguntas_PerguntaId",
                table: "Respostas");

            migrationBuilder.DropTable(
                name: "Formularios");

            migrationBuilder.DropIndex(
                name: "IX_Perguntas_FormularioId",
                table: "Perguntas");

            migrationBuilder.DropColumn(
                name: "FormularioId",
                table: "Perguntas");

            migrationBuilder.AlterColumn<int>(
                name: "PerguntaId",
                table: "Respostas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Perguntas_PerguntaId",
                table: "Respostas",
                column: "PerguntaId",
                principalTable: "Perguntas",
                principalColumn: "PerguntaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
