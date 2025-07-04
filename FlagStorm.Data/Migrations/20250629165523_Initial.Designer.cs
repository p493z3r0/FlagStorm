﻿// <auto-generated />
using System;
using System.Collections.Generic;
using FlagStorm.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlagStorm.Data.Migrations
{
    [DbContext(typeof(FlagStormDbContext))]
    [Migration("20250629165523_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AccountId", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FlagStormTargetRuleId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FlagStormTargetRuleId");

                    b.ToTable("AccountIds");
                });

            modelBuilder.Entity("AppVersion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AppVersion");
                });

            modelBuilder.Entity("Browser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FlagStormTargetRuleId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FlagStormTargetRuleId");

                    b.ToTable("Browsers");
                });

            modelBuilder.Entity("DeviceType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FlagStormTargetRuleId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FlagStormTargetRuleId");

                    b.ToTable("DeviceTypes");
                });

            modelBuilder.Entity("EnvironmentName", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FlagStormTargetRuleId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FlagStormTargetRuleId");

                    b.ToTable("Environments");
                });

            modelBuilder.Entity("FlagStorm.Data.Feature.AppVersionRange", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FlagStormTargetRuleId")
                        .HasColumnType("text");

                    b.Property<string>("MaxId")
                        .HasColumnType("text");

                    b.Property<string>("MinId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FlagStormTargetRuleId")
                        .IsUnique();

                    b.HasIndex("MaxId");

                    b.HasIndex("MinId");

                    b.ToTable("VersionRanges");
                });

            modelBuilder.Entity("FlagStorm.Data.Feature.FlagStormFeature", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.PrimitiveCollection<IReadOnlySet<string>>("Tags")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("FlagStorm.Data.Feature.FlagStormFeatureRuntimeConfig", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FlagStormFeatureId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RunPercentage")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FlagStormFeatureId")
                        .IsUnique();

                    b.ToTable("RuntimeConfigs");
                });

            modelBuilder.Entity("FlagStorm.Data.Feature.FlagStormTargetRule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsAllowRule")
                        .HasColumnType("boolean");

                    b.Property<string>("RuntimeConfigId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RuntimeConfigId");

                    b.ToTable("TargetRules");
                });

            modelBuilder.Entity("Locale", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FlagStormTargetRuleId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FlagStormTargetRuleId");

                    b.ToTable("Locales");
                });

            modelBuilder.Entity("OperatingSystem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FlagStormTargetRuleId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FlagStormTargetRuleId");

                    b.ToTable("OperatingSystems");
                });

            modelBuilder.Entity("Region", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FlagStormTargetRuleId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FlagStormTargetRuleId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("AccountId", b =>
                {
                    b.HasOne("FlagStorm.Data.Feature.FlagStormTargetRule", null)
                        .WithMany("AccountIds")
                        .HasForeignKey("FlagStormTargetRuleId");
                });

            modelBuilder.Entity("Browser", b =>
                {
                    b.HasOne("FlagStorm.Data.Feature.FlagStormTargetRule", null)
                        .WithMany("Browsers")
                        .HasForeignKey("FlagStormTargetRuleId");
                });

            modelBuilder.Entity("DeviceType", b =>
                {
                    b.HasOne("FlagStorm.Data.Feature.FlagStormTargetRule", null)
                        .WithMany("DeviceTypes")
                        .HasForeignKey("FlagStormTargetRuleId");
                });

            modelBuilder.Entity("EnvironmentName", b =>
                {
                    b.HasOne("FlagStorm.Data.Feature.FlagStormTargetRule", null)
                        .WithMany("Environments")
                        .HasForeignKey("FlagStormTargetRuleId");
                });

            modelBuilder.Entity("FlagStorm.Data.Feature.AppVersionRange", b =>
                {
                    b.HasOne("FlagStorm.Data.Feature.FlagStormTargetRule", null)
                        .WithOne("AppVersionRange")
                        .HasForeignKey("FlagStorm.Data.Feature.AppVersionRange", "FlagStormTargetRuleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppVersion", "Max")
                        .WithMany()
                        .HasForeignKey("MaxId");

                    b.HasOne("AppVersion", "Min")
                        .WithMany()
                        .HasForeignKey("MinId");

                    b.Navigation("Max");

                    b.Navigation("Min");
                });

            modelBuilder.Entity("FlagStorm.Data.Feature.FlagStormFeatureRuntimeConfig", b =>
                {
                    b.HasOne("FlagStorm.Data.Feature.FlagStormFeature", null)
                        .WithOne("RuntimeConfig")
                        .HasForeignKey("FlagStorm.Data.Feature.FlagStormFeatureRuntimeConfig", "FlagStormFeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlagStorm.Data.Feature.FlagStormTargetRule", b =>
                {
                    b.HasOne("FlagStorm.Data.Feature.FlagStormFeatureRuntimeConfig", null)
                        .WithMany("TargetRules")
                        .HasForeignKey("RuntimeConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Locale", b =>
                {
                    b.HasOne("FlagStorm.Data.Feature.FlagStormTargetRule", null)
                        .WithMany("Locales")
                        .HasForeignKey("FlagStormTargetRuleId");
                });

            modelBuilder.Entity("OperatingSystem", b =>
                {
                    b.HasOne("FlagStorm.Data.Feature.FlagStormTargetRule", null)
                        .WithMany("OperatingSystems")
                        .HasForeignKey("FlagStormTargetRuleId");
                });

            modelBuilder.Entity("Region", b =>
                {
                    b.HasOne("FlagStorm.Data.Feature.FlagStormTargetRule", null)
                        .WithMany("Regions")
                        .HasForeignKey("FlagStormTargetRuleId");
                });

            modelBuilder.Entity("FlagStorm.Data.Feature.FlagStormFeature", b =>
                {
                    b.Navigation("RuntimeConfig")
                        .IsRequired();
                });

            modelBuilder.Entity("FlagStorm.Data.Feature.FlagStormFeatureRuntimeConfig", b =>
                {
                    b.Navigation("TargetRules");
                });

            modelBuilder.Entity("FlagStorm.Data.Feature.FlagStormTargetRule", b =>
                {
                    b.Navigation("AccountIds");

                    b.Navigation("AppVersionRange");

                    b.Navigation("Browsers");

                    b.Navigation("DeviceTypes");

                    b.Navigation("Environments");

                    b.Navigation("Locales");

                    b.Navigation("OperatingSystems");

                    b.Navigation("Regions");
                });
#pragma warning restore 612, 618
        }
    }
}
