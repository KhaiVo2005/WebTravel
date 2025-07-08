using Microsoft.EntityFrameworkCore;

namespace WebTravel.Data
{
    public class TravelDbContext: DbContext
    {
        public TravelDbContext(DbContextOptions<TravelDbContext> options): base(options)
        {
        }

        public DbSet<DiaDiem> DiaDiems { get; set; }
        public DbSet<LoaiDichVu> LoaiDichVus { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<KhachHang_LoaiDichVu> KhachHang_LoaiDichVus { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<TourCaNhan> TourCaNhans { get; set; }
        public DbSet<DiaDiemTour> DiaDiemTours { get; set; }
        public DbSet<DanhGiaDichVu> DanhGiaDichVus { get; set; }
        public DbSet<DanhGiaDiaDiem> DanhGiaDiaDiems { get; set; }
        public DbSet<BaiDang> BaiDangs { get; set; }
        public DbSet<CmtBaiDang> CmtBaiDangs { get; set; }
        public DbSet<ThanhPho> ThanhPhos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // ==== Khóa chính tổng hợp ====
        //    modelBuilder.Entity<DiaDiemTour>()
        //        .HasKey(e => new { e.MaDiaDiemTour, e.MaTour, e.MaDiaDiem });

        //    modelBuilder.Entity<KhachHang_LoaiDichVu>()
        //        .HasKey(e => e.MaThue);

        //    // ==== Quan hệ 1-n, n-n ====

        //    // DiaDiem - ThanhPho
        //    modelBuilder.Entity<DiaDiem>()
        //        .HasOne(d => d.ThanhPho)
        //        .WithMany(tp => tp.DiaDiems)
        //        .HasForeignKey(d => d.MaTP)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // LoaiDichVu - NhanVien
        //    modelBuilder.Entity<LoaiDichVu>()
        //        .HasOne(ldv => ldv.NhanVien)
        //        .WithMany(nv => nv.LoaiDichVus)
        //        .HasForeignKey(ldv => ldv.MaNV)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // LoaiDichVu - DiaDiem
        //    modelBuilder.Entity<LoaiDichVu>()
        //        .HasOne(ldv => ldv.DiaDiem)
        //        .WithMany(dd => dd.LoaiDichVus)
        //        .HasForeignKey(ldv => ldv.MaDD)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // DiaDiemTour - TourCaNhan
        //    modelBuilder.Entity<DiaDiemTour>()
        //        .HasOne(dt => dt.TourCaNhan)
        //        .WithMany(t => t.DiaDiemTours)
        //        .HasForeignKey(dt => dt.MaTour)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // DiaDiemTour - DiaDiem
        //    modelBuilder.Entity<DiaDiemTour>()
        //        .HasOne(dt => dt.DiaDiem)
        //        .WithMany(d => d.DiaDiemTours)
        //        .HasForeignKey(dt => dt.MaDiaDiem)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // TourCaNhan - KhachHang
        //    modelBuilder.Entity<TourCaNhan>()
        //        .HasOne(t => t.KhachHang)
        //        .WithMany(kh => kh.TourCaNhans)
        //        .HasForeignKey(t => t.MaKH)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // KhachHang_LoaiDichVu - DiaDiemTour
        //    modelBuilder.Entity<KhachHang_LoaiDichVu>()
        //        .HasOne(kldv => kldv.DiaDiemTour)
        //        .WithMany(dt => dt.KhachHang_LoaiDichVus)
        //        .HasForeignKey(kldv => kldv.MaDiaDiemTour)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // DanhGiaDichVu - KhachHang_LoaiDichVu
        //    modelBuilder.Entity<DanhGiaDichVu>()
        //        .HasOne(dg => dg.KhachHang_LoaiDichVu)
        //        .WithMany(k => k.DanhGiaDichVus)
        //        .HasForeignKey(dg => dg.MaThue)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // DanhGiaDiaDiem - DiaDiem
        //    modelBuilder.Entity<DanhGiaDiaDiem>()
        //        .HasOne(dg => dg.DiaDiem)
        //        .WithMany(dd => dd.DanhGiaDiaDiems)
        //        .HasForeignKey(dg => dg.MaDD)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // BaiDang - KhachHang
        //    modelBuilder.Entity<BaiDang>()
        //        .HasOne(bd => bd.KhachHang)
        //        .WithMany(kh => kh.BaiDangs)
        //        .HasForeignKey(bd => bd.MaKH)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // CmtBaiDang - BaiDang
        //    modelBuilder.Entity<CmtBaiDang>()
        //        .HasOne(c => c.BaiDang)
        //        .WithMany(bd => bd.CmtBaiDangs)
        //        .HasForeignKey(c => c.MaBaiDang)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}

    }
}
