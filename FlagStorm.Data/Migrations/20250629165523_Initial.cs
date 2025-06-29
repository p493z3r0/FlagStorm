using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlagStorm.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppVersion",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppVersion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsDisabled = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Tags = table.Column<IReadOnlySet<string>>(type: "text[]", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RuntimeConfigs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    RunPercentage = table.Column<int>(type: "integer", nullable: false),
                    FlagStormFeatureId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuntimeConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuntimeConfigs_Features_FlagStormFeatureId",
                        column: x => x.FlagStormFeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TargetRules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    IsAllowRule = table.Column<bool>(type: "boolean", nullable: false),
                    RuntimeConfigId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TargetRules_RuntimeConfigs_RuntimeConfigId",
                        column: x => x.RuntimeConfigId,
                        principalTable: "RuntimeConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountIds",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    FlagStormTargetRuleId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountIds_TargetRules_FlagStormTargetRuleId",
                        column: x => x.FlagStormTargetRuleId,
                        principalTable: "TargetRules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Browsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    FlagStormTargetRuleId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Browsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Browsers_TargetRules_FlagStormTargetRuleId",
                        column: x => x.FlagStormTargetRuleId,
                        principalTable: "TargetRules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeviceTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    FlagStormTargetRuleId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceTypes_TargetRules_FlagStormTargetRuleId",
                        column: x => x.FlagStormTargetRuleId,
                        principalTable: "TargetRules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Environments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    FlagStormTargetRuleId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Environments_TargetRules_FlagStormTargetRuleId",
                        column: x => x.FlagStormTargetRuleId,
                        principalTable: "TargetRules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Locales",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    FlagStormTargetRuleId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locales_TargetRules_FlagStormTargetRuleId",
                        column: x => x.FlagStormTargetRuleId,
                        principalTable: "TargetRules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperatingSystems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FlagStormTargetRuleId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperatingSystems_TargetRules_FlagStormTargetRuleId",
                        column: x => x.FlagStormTargetRuleId,
                        principalTable: "TargetRules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    FlagStormTargetRuleId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_TargetRules_FlagStormTargetRuleId",
                        column: x => x.FlagStormTargetRuleId,
                        principalTable: "TargetRules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VersionRanges",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    MinId = table.Column<string>(type: "text", nullable: true),
                    MaxId = table.Column<string>(type: "text", nullable: true),
                    FlagStormTargetRuleId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VersionRanges_AppVersion_MaxId",
                        column: x => x.MaxId,
                        principalTable: "AppVersion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VersionRanges_AppVersion_MinId",
                        column: x => x.MinId,
                        principalTable: "AppVersion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VersionRanges_TargetRules_FlagStormTargetRuleId",
                        column: x => x.FlagStormTargetRuleId,
                        principalTable: "TargetRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountIds_FlagStormTargetRuleId",
                table: "AccountIds",
                column: "FlagStormTargetRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Browsers_FlagStormTargetRuleId",
                table: "Browsers",
                column: "FlagStormTargetRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypes_FlagStormTargetRuleId",
                table: "DeviceTypes",
                column: "FlagStormTargetRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Environments_FlagStormTargetRuleId",
                table: "Environments",
                column: "FlagStormTargetRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Locales_FlagStormTargetRuleId",
                table: "Locales",
                column: "FlagStormTargetRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingSystems_FlagStormTargetRuleId",
                table: "OperatingSystems",
                column: "FlagStormTargetRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_FlagStormTargetRuleId",
                table: "Regions",
                column: "FlagStormTargetRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RuntimeConfigs_FlagStormFeatureId",
                table: "RuntimeConfigs",
                column: "FlagStormFeatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TargetRules_RuntimeConfigId",
                table: "TargetRules",
                column: "RuntimeConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_VersionRanges_FlagStormTargetRuleId",
                table: "VersionRanges",
                column: "FlagStormTargetRuleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VersionRanges_MaxId",
                table: "VersionRanges",
                column: "MaxId");

            migrationBuilder.CreateIndex(
                name: "IX_VersionRanges_MinId",
                table: "VersionRanges",
                column: "MinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountIds");

            migrationBuilder.DropTable(
                name: "Browsers");

            migrationBuilder.DropTable(
                name: "DeviceTypes");

            migrationBuilder.DropTable(
                name: "Environments");

            migrationBuilder.DropTable(
                name: "Locales");

            migrationBuilder.DropTable(
                name: "OperatingSystems");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "VersionRanges");

            migrationBuilder.DropTable(
                name: "AppVersion");

            migrationBuilder.DropTable(
                name: "TargetRules");

            migrationBuilder.DropTable(
                name: "RuntimeConfigs");

            migrationBuilder.DropTable(
                name: "Features");
        }
    }
}
