using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bai3.Models
{
    public partial class QuanLyBenhNhanDBBContext : DbContext
    {
        public QuanLyBenhNhanDBBContext()
        {
        }

        public QuanLyBenhNhanDBBContext(DbContextOptions<QuanLyBenhNhanDBBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BenhNhan> BenhNhans { get; set; } = null!;
        public virtual DbSet<Khoa> Khoas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-OPQKFUV;Initial Catalog=QuanLyBenhNhanDBB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BenhNhan>(entity =>
            {
                entity.HasKey(e => e.MaBn)
                    .HasName("PK__BenhNhan__272475AD47855970");

                entity.ToTable("BenhNhan");

                entity.Property(e => e.MaBn)
                    .ValueGeneratedNever()
                    .HasColumnName("MaBN");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.BenhNhans)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("FK__BenhNhan__MaKhoa__267ABA7A");
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.MaKhoa)
                    .HasName("PK__Khoa__65390405AB2DF7E9");

                entity.ToTable("Khoa");

                entity.Property(e => e.MaKhoa).ValueGeneratedNever();

                entity.Property(e => e.TenKhoa).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
