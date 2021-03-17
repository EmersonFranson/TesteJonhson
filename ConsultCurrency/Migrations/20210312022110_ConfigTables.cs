using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultCurrency.Migrations
{
    public partial class ConfigTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cambio_Moeda_MoedaID_MOEDA",
                table: "Cambio");

            migrationBuilder.DropColumn(
                name: "ID_MOEDA",
                table: "Cambio");

            migrationBuilder.AlterColumn<int>(
                name: "MoedaID_MOEDA",
                table: "Cambio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cambio_Moeda_MoedaID_MOEDA",
                table: "Cambio",
                column: "MoedaID_MOEDA",
                principalTable: "Moeda",
                principalColumn: "ID_MOEDA",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cambio_Moeda_MoedaID_MOEDA",
                table: "Cambio");

            migrationBuilder.AlterColumn<int>(
                name: "MoedaID_MOEDA",
                table: "Cambio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ID_MOEDA",
                table: "Cambio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cambio_Moeda_MoedaID_MOEDA",
                table: "Cambio",
                column: "MoedaID_MOEDA",
                principalTable: "Moeda",
                principalColumn: "ID_MOEDA",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
