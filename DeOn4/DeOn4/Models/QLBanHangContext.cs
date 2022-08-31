using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DeOn4.Models
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

        public virtual DbSet<DanhMucHang> DanhMucHangs { get; set; } = null!;
        public virtual DbSet<Hang> Hangs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=desktop-opqkfuv;Initial Catalog=QLBanHang;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMucHang>(entity =>
            {
                entity.HasKey(e => e.MaDm)
                    .HasName("PK__DanhMucH__2725866E944D103B");

                entity.ToTable("DanhMucHang");

                entity.Property(e => e.MaDm)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MaDM")
                    .IsFixedLength();

                entity.Property(e => e.TenDm)
                    .HasMaxLength(50)
                    .HasColumnName("TenDM");
            });

            modelBuilder.Entity<Hang>(entity =>
            {
                entity.HasKey(e => e.MaHang)
                    .HasName("PK__Hang__19C0DB1DF9C9287B");

                entity.ToTable("Hang");

                entity.Property(e => e.MaHang)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaDm)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MaDM")
                    .IsFixedLength();

                entity.Property(e => e.TenHang).HasMaxLength(30);

                entity.HasOne(d => d.MaDmNavigation)
                    .WithMany(p => p.Hangs)
                    .HasForeignKey(d => d.MaDm)
                    .HasConstraintName("FK__Hang__MaDM__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
