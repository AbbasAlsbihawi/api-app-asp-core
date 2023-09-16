﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_app.Data;

#nullable disable

namespace api_app.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("api_app.models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserName = "abbas"
                        },
                        new
                        {
                            Id = 2,
                            UserName = "ali"
                        },
                        new
                        {
                            Id = 3,
                            UserName = "ahmed"
                        },
                        new
                        {
                            Id = 4,
                            UserName = "mohammed"
                        },
                        new
                        {
                            Id = 5,
                            UserName = "kadem"
                        },
                        new
                        {
                            Id = 6,
                            UserName = "hussain"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}