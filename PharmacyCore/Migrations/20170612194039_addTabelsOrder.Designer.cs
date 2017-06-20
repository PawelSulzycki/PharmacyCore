using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PharmacyCore.DBContexts;

namespace PharmacyCore.Migrations
{
    [DbContext(typeof(PharmacyContext))]
    [Migration("20170612194039_addTabelsOrder")]
    partial class addTabelsOrder
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

            modelBuilder.Entity("PharmacyCore.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MedicineId");

                    b.Property<int>("Quantity");

                    b.Property<int>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PharmacyCore.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Login");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("Role");

                    b.Property<string>("Street");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PharmacyCore.Models.Order", b =>
                {
                    b.HasOne("PharmacyCore.Models.Medicine", "Medicine")
                        .WithMany("Order")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PharmacyCore.Models.User", "User")
                        .WithMany("Order")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
