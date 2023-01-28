﻿// <auto-generated />
using App.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.DAL.Migrations
{
    [DbContext(typeof(ToDoContext))]
    [Migration("20230126221723_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.DAL.Model.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Date")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar");

                    b.Property<bool>("Urgently")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Assignments");
                });
#pragma warning restore 612, 618
        }
    }
}
