using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mf_apis_web_services_fuel_manager.Migrations
{
    /// <inheritdoc />
    public partial class M02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Href = table.Column<string>(type: "TEXT", nullable: true),
                    Rel = table.Column<string>(type: "TEXT", nullable: true),
                    Metodo = table.Column<string>(type: "TEXT", nullable: true),
                    ConsumoId = table.Column<int>(type: "INTEGER", nullable: true),
                    VeiculoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkDto_Consumos_ConsumoId",
                        column: x => x.ConsumoId,
                        principalTable: "Consumos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LinkDto_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Perfil = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VeiculoUsuarios",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConsumoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculoUsuarios", x => new { x.VeiculoId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_VeiculoUsuarios_Consumos_ConsumoId",
                        column: x => x.ConsumoId,
                        principalTable: "Consumos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VeiculoUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeiculoUsuarios_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkDto_ConsumoId",
                table: "LinkDto",
                column: "ConsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkDto_VeiculoId",
                table: "LinkDto",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoUsuarios_ConsumoId",
                table: "VeiculoUsuarios",
                column: "ConsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoUsuarios_UsuarioId",
                table: "VeiculoUsuarios",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkDto");

            migrationBuilder.DropTable(
                name: "VeiculoUsuarios");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
