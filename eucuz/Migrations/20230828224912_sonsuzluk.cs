using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eucuz.Migrations
{
    public partial class sonsuzluk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kategorilers_urunlers_Urunlerurun_Id",
                table: "kategorilers");

            migrationBuilder.DropIndex(
                name: "IX_kategorilers_Urunlerurun_Id",
                table: "kategorilers");

            migrationBuilder.DropColumn(
                name: "Urunlerurun_Id",
                table: "kategorilers");

            migrationBuilder.CreateIndex(
                name: "IX_urunlers_kategori_Id",
                table: "urunlers",
                column: "kategori_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_urunlers_kategorilers_kategori_Id",
                table: "urunlers",
                column: "kategori_Id",
                principalTable: "kategorilers",
                principalColumn: "kategori_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_urunlers_kategorilers_kategori_Id",
                table: "urunlers");

            migrationBuilder.DropIndex(
                name: "IX_urunlers_kategori_Id",
                table: "urunlers");

            migrationBuilder.AddColumn<int>(
                name: "Urunlerurun_Id",
                table: "kategorilers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_kategorilers_Urunlerurun_Id",
                table: "kategorilers",
                column: "Urunlerurun_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_kategorilers_urunlers_Urunlerurun_Id",
                table: "kategorilers",
                column: "Urunlerurun_Id",
                principalTable: "urunlers",
                principalColumn: "urun_Id");
        }
    }
}
