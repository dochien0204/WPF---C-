using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DeOn3.Models
{
    public partial class QLNhanvienContext : DbContext
    {
        public QLNhanvienContext()
        {
        }

        public QLNhanvienContext(DbContextOptions<QLNhanvienContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;
        public virtual DbSet<PhongBan> PhongBans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=desktop-opqkfuv;Initial Catalog=QLNhanvien;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__Nhanvien__2725D70A7EFC53A6");

                entity.ToTable("Nhanvien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MaNV");

                entity.Property(e => e.Hoten).HasMaxLength(30);

                entity.Property(e => e.MaPhong).HasMaxLength(2);

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.Nhanviens)
                    .HasForeignKey(d => d.MaPhong)
                    .HasConstraintName("FK__Nhanvien__MaPhon__267ABA7A");
            });

            modelBuilder.Entity<PhongBan>(entity =>
            {
                entity.HasKey(e => e.MaPhong)
                    .HasName("PK__PhongBan__20BD5E5B4EA5107D");

                entity.ToTable("PhongBan");

                entity.Property(e => e.MaPhong).HasMaxLength(2);

                entity.Property(e => e.TenPhong).HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
