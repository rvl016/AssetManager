using System;
using AssetManager.Models.Accounting;
using AssetManager.Utils;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;


namespace AssetManager.Data
{

    public partial class AssetManagerDbContext : DbContext
    {

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountMove> AccountMoves { get; set; }

        public DbSet<AccountMoveLine> AccountMoveLines { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }

        public AssetManagerDbContext() {}

        public AssetManagerDbContext(DbContextOptions<AssetManagerDbContext> options) 
            : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>()
                .HasOne(e => e.Type)
                .WithMany(e => e.Accounts)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccountType>()
                .Property(e => e.Type)
                .HasConversion(
                    e => e.Label,
                    label => Enumeration.FromLabel<AccountTypeSelection>(label)
                );

            modelBuilder.Entity<AccountMove>()
                .Property(e => e.State)
                .HasConversion(
                    e => e.Label,
                    label => Enumeration.FromLabel<AccountMoveState>(label)
                );

            modelBuilder.Entity<AccountMoveLine>()
                .HasOne(e => e.Account)
                .WithMany(e => e.MoveLines)
                .HasForeignKey(e => e.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccountMoveLine>()
                .HasOne(e => e.Move)
                .WithMany(e => e.MoveLines)
                .HasForeignKey(e => e.MoveId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}