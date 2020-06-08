﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMovies.Data;

namespace MyMovies.Data.Migrations
{
    [DbContext(typeof(MyMoviesDBContext))]
    [Migration("20200608162727_AddedIsAdmin")]
    partial class AddedIsAdmin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyMovies.Data.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cast")
                        .IsRequired();

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Views");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MyMovies.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}