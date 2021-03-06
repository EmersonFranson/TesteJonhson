// <auto-generated />
using System;
using ConsultCurrency.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsultCurrency.Migrations
{
    [DbContext(typeof(ContextDb))]
    [Migration("20210312013740_CreateTables")]
    partial class CreateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ConsultCurrency.Models.Cambio", b =>
                {
                    b.Property<int>("ID_CAMBIO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ID_MOEDA")
                        .HasColumnType("int");

                    b.Property<int?>("MoedaID_MOEDA")
                        .HasColumnType("int");

                    b.Property<decimal>("VL_CAMBIO")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID_CAMBIO");

                    b.HasIndex("MoedaID_MOEDA");

                    b.ToTable("Cambio");
                });

            modelBuilder.Entity("ConsultCurrency.Models.Moeda", b =>
                {
                    b.Property<int>("ID_MOEDA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DS_MOEDA")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_MOEDA");

                    b.ToTable("Moeda");
                });

            modelBuilder.Entity("ConsultCurrency.Models.Cambio", b =>
                {
                    b.HasOne("ConsultCurrency.Models.Moeda", "Moeda")
                        .WithMany()
                        .HasForeignKey("MoedaID_MOEDA");

                    b.Navigation("Moeda");
                });
#pragma warning restore 612, 618
        }
    }
}
