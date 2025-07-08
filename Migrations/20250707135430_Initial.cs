using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTravel.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNV);
                });

            migrationBuilder.CreateTable(
                name: "ThanhPhos",
                columns: table => new
                {
                    MaTP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenThanhPho = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhPhos", x => x.MaTP);
                });

            migrationBuilder.CreateTable(
                name: "BaiDangs",
                columns: table => new
                {
                    MaBaiDang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LuotLike = table.Column<int>(type: "int", nullable: false),
                    MaKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiDangs", x => x.MaBaiDang);
                    table.ForeignKey(
                        name: "FK_BaiDangs_KhachHangs_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourCaNhans",
                columns: table => new
                {
                    MaTour = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenTour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourCaNhans", x => x.MaTour);
                    table.ForeignKey(
                        name: "FK_TourCaNhans_KhachHangs_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiaDiems",
                columns: table => new
                {
                    MaDD = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenDiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaTP = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDiems", x => x.MaDD);
                    table.ForeignKey(
                        name: "FK_DiaDiems_ThanhPhos_MaTP",
                        column: x => x.MaTP,
                        principalTable: "ThanhPhos",
                        principalColumn: "MaTP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CmtBaiDangs",
                columns: table => new
                {
                    MaDanhGia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaBaiDang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmtBaiDangs", x => x.MaDanhGia);
                    table.ForeignKey(
                        name: "FK_CmtBaiDangs_BaiDangs_MaBaiDang",
                        column: x => x.MaBaiDang,
                        principalTable: "BaiDangs",
                        principalColumn: "MaBaiDang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhGiaDiaDiems",
                columns: table => new
                {
                    MaDG = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoSao = table.Column<int>(type: "int", nullable: false),
                    AnhVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDD = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGiaDiaDiems", x => x.MaDG);
                    table.ForeignKey(
                        name: "FK_DanhGiaDiaDiems_DiaDiems_MaDD",
                        column: x => x.MaDD,
                        principalTable: "DiaDiems",
                        principalColumn: "MaDD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiaDiemTours",
                columns: table => new
                {
                    MaDiaDiemTour = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaTour = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDiaDiem = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDiemTours", x => x.MaDiaDiemTour);
                    table.ForeignKey(
                        name: "FK_DiaDiemTours_DiaDiems_MaDiaDiem",
                        column: x => x.MaDiaDiem,
                        principalTable: "DiaDiems",
                        principalColumn: "MaDD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiaDiemTours_TourCaNhans_MaTour",
                        column: x => x.MaTour,
                        principalTable: "TourCaNhans",
                        principalColumn: "MaTour",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDichVus",
                columns: table => new
                {
                    MaLoaiDV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenDV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaDV = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaNV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDD = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDichVus", x => x.MaLoaiDV);
                    table.ForeignKey(
                        name: "FK_LoaiDichVus_DiaDiems_MaDD",
                        column: x => x.MaDD,
                        principalTable: "DiaDiems",
                        principalColumn: "MaDD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoaiDichVus_NhanViens_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanViens",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang_LoaiDichVus",
                columns: table => new
                {
                    MaThue = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TuNgay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DenNgay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaDiaDiemTour = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaLoaiDV = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang_LoaiDichVus", x => x.MaThue);
                    table.ForeignKey(
                        name: "FK_KhachHang_LoaiDichVus_DiaDiemTours_MaDiaDiemTour",
                        column: x => x.MaDiaDiemTour,
                        principalTable: "DiaDiemTours",
                        principalColumn: "MaDiaDiemTour",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhGiaDichVus",
                columns: table => new
                {
                    MaDanhGia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DanhGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoSao = table.Column<int>(type: "int", nullable: false),
                    AnhVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaThue = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGiaDichVus", x => x.MaDanhGia);
                    table.ForeignKey(
                        name: "FK_DanhGiaDichVus_KhachHang_LoaiDichVus_MaThue",
                        column: x => x.MaThue,
                        principalTable: "KhachHang_LoaiDichVus",
                        principalColumn: "MaThue",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiDangs_MaKH",
                table: "BaiDangs",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_CmtBaiDangs_MaBaiDang",
                table: "CmtBaiDangs",
                column: "MaBaiDang");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGiaDiaDiems_MaDD",
                table: "DanhGiaDiaDiems",
                column: "MaDD");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGiaDichVus_MaThue",
                table: "DanhGiaDichVus",
                column: "MaThue");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiems_MaTP",
                table: "DiaDiems",
                column: "MaTP");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiemTours_MaDiaDiem",
                table: "DiaDiemTours",
                column: "MaDiaDiem");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiemTours_MaTour",
                table: "DiaDiemTours",
                column: "MaTour");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_LoaiDichVus_MaDiaDiemTour",
                table: "KhachHang_LoaiDichVus",
                column: "MaDiaDiemTour");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiDichVus_MaDD",
                table: "LoaiDichVus",
                column: "MaDD");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiDichVus_MaNV",
                table: "LoaiDichVus",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_TourCaNhans_MaKH",
                table: "TourCaNhans",
                column: "MaKH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CmtBaiDangs");

            migrationBuilder.DropTable(
                name: "DanhGiaDiaDiems");

            migrationBuilder.DropTable(
                name: "DanhGiaDichVus");

            migrationBuilder.DropTable(
                name: "LoaiDichVus");

            migrationBuilder.DropTable(
                name: "BaiDangs");

            migrationBuilder.DropTable(
                name: "KhachHang_LoaiDichVus");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "DiaDiemTours");

            migrationBuilder.DropTable(
                name: "DiaDiems");

            migrationBuilder.DropTable(
                name: "TourCaNhans");

            migrationBuilder.DropTable(
                name: "ThanhPhos");

            migrationBuilder.DropTable(
                name: "KhachHangs");
        }
    }
}
