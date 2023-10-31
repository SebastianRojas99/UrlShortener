﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using URLshorter;

#nullable disable

namespace URLshorter.Migrations
{
    [DbContext(typeof(URLshorterContext))]
    partial class URLshorterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("URLshorter.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("URLshorter.Entities.XYZ", b =>
                {
                    b.Property<int>("idURL")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VisitCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("urlOG")
                        .HasColumnType("TEXT");

                    b.Property<string>("urlShort")
                        .HasColumnType("TEXT");

                    b.HasKey("idURL");

                    b.HasIndex("CategoryId");

                    b.ToTable("MisURL");
                });

            modelBuilder.Entity("URLshorter.Entities.XYZ", b =>
                {
                    b.HasOne("URLshorter.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
