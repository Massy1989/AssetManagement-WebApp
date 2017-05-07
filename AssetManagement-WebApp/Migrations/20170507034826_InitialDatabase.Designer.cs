using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AssetManagementWebApp.Models;

namespace AssetManagementWebApp.Migrations
{
    [DbContext(typeof(AssetContext))]
    [Migration("20170507034826_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssetManagementWebApp.Models.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AssetTypeId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AssetTypeId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("AssetManagementWebApp.Models.AssetType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("AssetTypes");
                });

            modelBuilder.Entity("AssetManagementWebApp.Models.Asset", b =>
                {
                    b.HasOne("AssetManagementWebApp.Models.AssetType", "AssetType")
                        .WithMany()
                        .HasForeignKey("AssetTypeId");
                });
        }
    }
}
