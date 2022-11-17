using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class ATMmachine5Context : DbContext
    {
        public ATMmachine5Context()
        {
        }

        public ATMmachine5Context(DbContextOptions<ATMmachine5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CreditCard> CreditCards { get; set; } = null!;
        public virtual DbSet<Deposit> Deposits { get; set; } = null!;
        public virtual DbSet<Withdraw> Withdraws { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= LAPTOP-GTFR66J3; Database=ATMmachine5; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.HasKey(e => e.CardId)
                    .HasName("PK__CreditCa__55FECDAED8FC12BC");

                entity.ToTable("CreditCard");

                entity.HasIndex(e => e.CardNumber, "UQ__CreditCa__A4E9FFE97F4C114F")
                    .IsUnique();

                entity.HasIndex(e => e.Pin, "UQ__CreditCa__C570590374C5C713")
                    .IsUnique();

                entity.Property(e => e.CardId).ValueGeneratedNever();

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(64)
                    .IsFixedLength();

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.NameOfOwner)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pin)
                    .HasMaxLength(64)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Deposit>(entity =>
            {
                entity.ToTable("Deposit");

                entity.Property(e => e.DepositId).ValueGeneratedNever();

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(64)
                    .HasColumnName("cardNumber")
                    .IsFixedLength();

                entity.Property(e => e.DateOfDeposit).HasColumnType("date");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.Deposits)
                    .HasForeignKey(d => d.CardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deposit__CardId__2B3F6F97");
            });

            modelBuilder.Entity<Withdraw>(entity =>
            {
                entity.ToTable("Withdraw");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateofWithdraw).HasColumnType("date");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.Withdraws)
                    .HasForeignKey(d => d.CardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Withdraw__CardId__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
