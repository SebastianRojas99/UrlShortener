﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using URLshorter;

#nullable disable

namespace URLshorter.Migrations
{
    [DbContext(typeof(URLshorterContext))]
    [Migration("20231010040221_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("URLshorter.Entities.XYZ", b =>
                {
                    b.Property<int>("idURL")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("urlOG")
                        .HasColumnType("TEXT");

                    b.Property<string>("urlShort")
                        .HasColumnType("TEXT");

                    b.HasKey("idURL");

                    b.ToTable("MisURL");
                });
#pragma warning restore 612, 618
        }
    }
}
