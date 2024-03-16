﻿// <auto-generated />
using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataModel.Migrations
{
    [DbContext(typeof(DbContextData))]
    [Migration("20240219090137_initDb")]
    partial class initDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataModel.Model.FoodIngredient", b =>
                {
                    b.Property<int>("FoodIngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodIngredientId"));

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<string>("FoodIngredientCode")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FoodIngredientDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FoodIngredientName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("FoodIngredientId");

                    b.ToTable("FoodIngredient");
                });
#pragma warning restore 612, 618
        }
    }
}
