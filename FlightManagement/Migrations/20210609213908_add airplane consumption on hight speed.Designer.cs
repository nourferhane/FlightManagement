// <auto-generated />
using System;
using FlightManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightManagement.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210609213908_add airplane consumption on hight speed")]
    partial class addairplaneconsumptiononhightspeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlightManagement.Models.Airplane", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ConsumptionOnhightSpeed")
                        .HasColumnType("bigint");

                    b.Property<int>("MaxFuel")
                        .HasColumnType("int");

                    b.Property<int>("MaxSpeed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TakeOffFuelConsumption")
                        .HasColumnType("bigint");

                    b.HasKey("Code");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("FlightManagement.Models.Airport", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("Latitude")
                        .HasColumnType("bigint");

                    b.Property<long>("Longitude")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("FlightManagement.Models.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AeroportDepartCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AeroportDestinationCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AirplaneCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AeroportDepartCode");

                    b.HasIndex("AeroportDestinationCode");

                    b.HasIndex("AirplaneCode");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightManagement.Models.Flight", b =>
                {
                    b.HasOne("FlightManagement.Models.Airport", "AeroportDepart")
                        .WithMany()
                        .HasForeignKey("AeroportDepartCode");

                    b.HasOne("FlightManagement.Models.Airport", "AeroportDestination")
                        .WithMany()
                        .HasForeignKey("AeroportDestinationCode");

                    b.HasOne("FlightManagement.Models.Airplane", "Airplane")
                        .WithMany()
                        .HasForeignKey("AirplaneCode");

                    b.Navigation("AeroportDepart");

                    b.Navigation("AeroportDestination");

                    b.Navigation("Airplane");
                });
#pragma warning restore 612, 618
        }
    }
}
