using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MusicHistoryLastOne.Models;

namespace MusicHistoryLastOne.Migrations
{
    [DbContext(typeof(LastOneContext))]
    partial class LastOneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusicHistoryLastOne.Models.Albums", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlbumTitle");

                    b.Property<string>("Artist");

                    b.Property<string>("YearReleased");

                    b.HasKey("AlbumId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("MusicHistoryLastOne.Models.LastOneUsers", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("LastOneUsers");
                });

            modelBuilder.Entity("MusicHistoryLastOne.Models.Tracks", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlbumId");

                    b.Property<string>("Author");

                    b.Property<string>("Genre");

                    b.Property<string>("TrackTitle");

                    b.Property<int>("UserId");

                    b.HasKey("TrackId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("UserId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("MusicHistoryLastOne.Models.Tracks", b =>
                {
                    b.HasOne("MusicHistoryLastOne.Models.Albums")
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MusicHistoryLastOne.Models.LastOneUsers")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
