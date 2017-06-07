using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PharmacyCore.DBContexts;

namespace PharmacyCore.Migrations
{
    [DbContext(typeof(PharmacyContext))]
    [Migration("20170606210359_createDatabase")]
    partial class createDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PharmacyCore.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataExpiration");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<bool>("Perscription");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<bool>("Refunded");

                    b.Property<string>("StorageMethod");

                    b.Property<string>("Use");

                    b.HasKey("Id");

                    b.ToTable("Medicines");
                });
        }
    }
}
