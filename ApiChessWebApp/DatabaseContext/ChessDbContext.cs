using System.ComponentModel;
using ApiChessWebApp.DbDTos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApiChessWebApp.DatabaseContext
{
    public class ChessDbContext : DbContext
    {
        public DbSet<ChessStateDbDto> ChessState { get; set; }
        public DbSet<Player> Player { get; set; }

        public DbSet<GameStateDbDto> GameStateDbDto { get; set; }
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

            modelBuilder.Entity<ChessStateDbDto>(entity =>
            {
                entity.ToTable("ChessState");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.GameState)
                    .HasColumnType("JSON");
                entity.Property(e => e.UniqueKey)
                    .HasDefaultValueSql("UUID()");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Players");
                entity.HasKey(e => e.Id);
                //entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name);
                entity.Property(e => e.Color);
                entity.Property(e => e.IsWhite);
                entity.Property(e => e.IsMyTurn);
                entity.Property(e => e.TotalMovesCount);
                entity.Property(e => e.IsWinner);
                entity.Property(e => e.ChessStateId);
            });

            modelBuilder.Entity<GameStateDbDto>(entity =>
            {
                entity.ToTable("GameState");
                entity.HasKey(e => e.Id);
                //entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.ChessStateId);
                entity.Property(e => e.FirstPlayerId);
                entity.Property(e => e.SecondPlayerId);
                entity.Property(e => e.CreatedData);
                entity.Property(e => e.UpdatedData);
            });
        }
    }
}
