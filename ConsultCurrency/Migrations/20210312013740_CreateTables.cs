using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultCurrency.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moeda",
                columns: table => new
                {
                    ID_MOEDA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_MOEDA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moeda", x => x.ID_MOEDA);
                });

            migrationBuilder.CreateTable(
                name: "Cambio",
                columns: table => new
                {
                    ID_CAMBIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_MOEDA = table.Column<int>(type: "int", nullable: false),
                    VL_CAMBIO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoedaID_MOEDA = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cambio", x => x.ID_CAMBIO);
                    table.ForeignKey(
                        name: "FK_Cambio_Moeda_MoedaID_MOEDA",
                        column: x => x.MoedaID_MOEDA,
                        principalTable: "Moeda",
                        principalColumn: "ID_MOEDA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cambio_MoedaID_MOEDA",
                table: "Cambio",
                column: "MoedaID_MOEDA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cambio");

            migrationBuilder.DropTable(
                name: "Moeda");
        }
    }
}
