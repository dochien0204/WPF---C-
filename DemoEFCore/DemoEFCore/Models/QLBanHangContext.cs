using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoEFCore.Models
{
    public partial class QLBanHangContext : DbContext
    {
        public QLBanHangContext()
        {
        }

        public QLBanHangContext(DbContextOptions<QLBanHangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Loaisp> Loaisps { get; set; } = null!;
        public virtual DbSet<Lsp> Lsps { get; set; } = null!;
        public virtual DbSet<Sp> Sps { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-OPQKFUV;Initial Catalog=QLBanHang;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loaisp>(entity =>
            {
                entity.HasKey(e => e.Maloai)
                    .HasName("PK__loaisp__734B3AEAD6FA94F5");

                entity.ToTable("loaisp");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(30)
                    .HasColumnName("maloai");

                entity.Property(e => e.Tenloai)
                    .HasMaxLength(30)
                    .HasColumnName("tenloai");
            });

            modelBuilder.Entity<Lsp>(entity =>
            {
                entity.HasKey(e => e.Maloai)
                    .HasName("PK__lsp__734B3AEA83B7C7F5");

                entity.ToTable("lsp");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(5)
                    .HasColumnName("maloai")
                    .IsFixedLength();

                entity.Property(e => e.Tenloai)
                    .HasMaxLength(30)
                    .HasColumnName("tenloai");
            });

            modelBuilder.Entity<Sp>(entity =>
            {
                entity.HasKey(e => e.Masp)
                    .HasName("PK__sp__7A217672680DE258");

                entity.ToTable("sp");

                entity.Property(e => e.Masp)
                    .HasMaxLength(5)
                    .HasColumnName("masp")
                    .IsFixedLength();

                entity.Property(e => e.Dongia).HasColumnName("dongia");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(5)
                    .HasColumnName("maloai")
                    .IsFixedLength();

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.Property(e => e.Tensp)
                    .HasMaxLength(30)
                    .HasColumnName("tensp");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Sps)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("fk_sp");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
