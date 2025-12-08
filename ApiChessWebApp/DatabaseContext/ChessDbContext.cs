using System.ComponentModel;
using ApiChessWebApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApiChessWebApp.DatabaseContext
{
    public class ChessDbContext : DbContext
    {
        public DbSet<ChessState> ChessState { get; set; }

        public ChessDbContext(DbContextOptions<ChessDbContext> options): base(options)
        {
        }

        //public ChessDbContext(DbContextOptionsBuilder db): base(db)
        //{

        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql(ServerVersion.AutoDetect(@"server=localhost;Database=chesswebapp;User=root;password=9044;Integrated Security=True")
        //        );
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ChessState>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //});

            //modelBuilder.Entity<ChessState>(entity =>
            //{
            //    entity.Property(e => e.GameState);
            //});

            modelBuilder.Entity<ChessState>(entity =>
            {
                entity.ToTable("ChessState");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.GameState)
                    .HasColumnType("JSON");

                entity.Property(e => e.UniqueKey)
                    .HasDefaultValueSql("UUID()");
            });
        }
    }
}
