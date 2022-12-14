// <auto-generated />
using System;
using Automation.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Automation.WebApi.Data.Migrations
{
    [DbContext(typeof(AutomationDBContext))]
    [Migration("20221123184012_CreateIndexAndDataCreatedOnDevice")]
    partial class CreateIndexAndDataCreatedOnDevice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.11");

            modelBuilder.Entity("Automation.WebApi.Data.Entities.Device", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeviceExternalId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastCommunication")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeviceExternalId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Automation.WebApi.Data.Entities.Humidity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateInserted")
                        .HasColumnType("TEXT");

                    b.Property<long>("DeviceId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("DateCreated");

                    b.HasIndex("DeviceId");

                    b.ToTable("Humidities");
                });
#pragma warning restore 612, 618
        }
    }
}
