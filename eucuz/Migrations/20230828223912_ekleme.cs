using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eucuz.Migrations
{
    public partial class ekleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    admin_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.admin_Id);
                });

            migrationBuilder.CreateTable(
                name: "urunlers",
                columns: table => new
                {
                    urun_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urun_Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urun_Kodu = table.Column<int>(type: "int", nullable: false),
                    urun_fiyat = table.Column<int>(type: "int", nullable: false),
                    resim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    indirim = table.Column<int>(type: "int", nullable: false),
                    kategori_Id = table.Column<int>(type: "int", nullable: false),
                    birim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    olcut = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urunlers", x => x.urun_Id);
                });

            migrationBuilder.CreateTable(
                name: "kategorilers",
                columns: table => new
                {
                    kategori_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kategori_Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Urunlerurun_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategorilers", x => x.kategori_Id);
                    table.ForeignKey(
                        name: "FK_kategorilers_urunlers_Urunlerurun_Id",
                        column: x => x.Urunlerurun_Id,
                        principalTable: "urunlers",
                        principalColumn: "urun_Id");
                });

            migrationBuilder.CreateTable(
                name: "sepet",
                columns: table => new
                {
                    sepet_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urun_Id = table.Column<int>(type: "int", nullable: false),
                    urunlersurun_Id = table.Column<int>(type: "int", nullable: false),
                    adet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sepet", x => x.sepet_Id);
                    table.ForeignKey(
                        name: "FK_sepet_urunlers_urunlersurun_Id",
                        column: x => x.urunlersurun_Id,
                        principalTable: "urunlers",
                        principalColumn: "urun_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "siparislers",
                columns: table => new
                {
                    siparis_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urun_Id = table.Column<int>(type: "int", nullable: false),
                    adet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_siparislers", x => x.siparis_Id);
                    table.ForeignKey(
                        name: "FK_siparislers_urunlers_urun_Id",
                        column: x => x.urun_Id,
                        principalTable: "urunlers",
                        principalColumn: "urun_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_kategorilers_Urunlerurun_Id",
                table: "kategorilers",
                column: "Urunlerurun_Id");

            migrationBuilder.CreateIndex(
                name: "IX_sepet_urunlersurun_Id",
                table: "sepet",
                column: "urunlersurun_Id");

            migrationBuilder.CreateIndex(
                name: "IX_siparislers_urun_Id",
                table: "siparislers",
                column: "urun_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "kategorilers");

            migrationBuilder.DropTable(
                name: "sepet");

            migrationBuilder.DropTable(
                name: "siparislers");

            migrationBuilder.DropTable(
                name: "urunlers");
        }
    }
}
