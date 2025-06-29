using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlagStorm.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountIds_TargetRules_FlagStormTargetRuleId",
                table: "AccountIds");

            migrationBuilder.DropForeignKey(
                name: "FK_Browsers_TargetRules_FlagStormTargetRuleId",
                table: "Browsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceTypes_TargetRules_FlagStormTargetRuleId",
                table: "DeviceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Environments_TargetRules_FlagStormTargetRuleId",
                table: "Environments");

            migrationBuilder.DropForeignKey(
                name: "FK_Locales_TargetRules_FlagStormTargetRuleId",
                table: "Locales");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatingSystems_TargetRules_FlagStormTargetRuleId",
                table: "OperatingSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_Regions_TargetRules_FlagStormTargetRuleId",
                table: "Regions");

            migrationBuilder.DropForeignKey(
                name: "FK_VersionRanges_AppVersion_MaxId",
                table: "VersionRanges");

            migrationBuilder.DropForeignKey(
                name: "FK_VersionRanges_AppVersion_MinId",
                table: "VersionRanges");

            migrationBuilder.DropTable(
                name: "AppVersion");

            migrationBuilder.RenameColumn(
                name: "FlagStormTargetRuleId",
                table: "Regions",
                newName: "FlagStormTargetRuleEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Regions_FlagStormTargetRuleId",
                table: "Regions",
                newName: "IX_Regions_FlagStormTargetRuleEntityId");

            migrationBuilder.RenameColumn(
                name: "FlagStormTargetRuleId",
                table: "OperatingSystems",
                newName: "FlagStormTargetRuleEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_OperatingSystems_FlagStormTargetRuleId",
                table: "OperatingSystems",
                newName: "IX_OperatingSystems_FlagStormTargetRuleEntityId");

            migrationBuilder.RenameColumn(
                name: "FlagStormTargetRuleId",
                table: "Locales",
                newName: "FlagStormTargetRuleEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Locales_FlagStormTargetRuleId",
                table: "Locales",
                newName: "IX_Locales_FlagStormTargetRuleEntityId");

            migrationBuilder.RenameColumn(
                name: "FlagStormTargetRuleId",
                table: "Environments",
                newName: "FlagStormTargetRuleEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Environments_FlagStormTargetRuleId",
                table: "Environments",
                newName: "IX_Environments_FlagStormTargetRuleEntityId");

            migrationBuilder.RenameColumn(
                name: "FlagStormTargetRuleId",
                table: "DeviceTypes",
                newName: "FlagStormTargetRuleEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceTypes_FlagStormTargetRuleId",
                table: "DeviceTypes",
                newName: "IX_DeviceTypes_FlagStormTargetRuleEntityId");

            migrationBuilder.RenameColumn(
                name: "FlagStormTargetRuleId",
                table: "Browsers",
                newName: "FlagStormTargetRuleEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Browsers_FlagStormTargetRuleId",
                table: "Browsers",
                newName: "IX_Browsers_FlagStormTargetRuleEntityId");

            migrationBuilder.RenameColumn(
                name: "FlagStormTargetRuleId",
                table: "AccountIds",
                newName: "FlagStormTargetRuleEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountIds_FlagStormTargetRuleId",
                table: "AccountIds",
                newName: "IX_AccountIds_FlagStormTargetRuleEntityId");

            migrationBuilder.CreateTable(
                name: "AppVersionEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppVersionEntity", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountIds_TargetRules_FlagStormTargetRuleEntityId",
                table: "AccountIds",
                column: "FlagStormTargetRuleEntityId",
                principalTable: "TargetRules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Browsers_TargetRules_FlagStormTargetRuleEntityId",
                table: "Browsers",
                column: "FlagStormTargetRuleEntityId",
                principalTable: "TargetRules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceTypes_TargetRules_FlagStormTargetRuleEntityId",
                table: "DeviceTypes",
                column: "FlagStormTargetRuleEntityId",
                principalTable: "TargetRules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Environments_TargetRules_FlagStormTargetRuleEntityId",
                table: "Environments",
                column: "FlagStormTargetRuleEntityId",
                principalTable: "TargetRules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locales_TargetRules_FlagStormTargetRuleEntityId",
                table: "Locales",
                column: "FlagStormTargetRuleEntityId",
                principalTable: "TargetRules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatingSystems_TargetRules_FlagStormTargetRuleEntityId",
                table: "OperatingSystems",
                column: "FlagStormTargetRuleEntityId",
                principalTable: "TargetRules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_TargetRules_FlagStormTargetRuleEntityId",
                table: "Regions",
                column: "FlagStormTargetRuleEntityId",
                principalTable: "TargetRules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VersionRanges_AppVersionEntity_MaxId",
                table: "VersionRanges",
                column: "MaxId",
                principalTable: "AppVersionEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VersionRanges_AppVersionEntity_MinId",
                table: "VersionRanges",
                column: "MinId",
                principalTable: "AppVersionEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountIds_TargetRules_FlagStormTargetRuleEntityId",
                table: "AccountIds");

            migrationBuilder.DropForeignKey(
                name: "FK_Browsers_TargetRules_FlagStormTargetRuleEntityId",
                table: "Browsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceTypes_TargetRules_FlagStormTargetRuleEntityId",
                table: "DeviceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Environments_TargetRules_FlagStormTargetRuleEntityId",
                table: "Environments");

            migrationBuilder.DropForeignKey(
                name: "FK_Locales_TargetRules_FlagStormTargetRuleEntityId",
                table: "Locales");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatingSystems_TargetRules_FlagStormTargetRuleEntityId",
                table: "OperatingSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_Regions_TargetRules_FlagStormTargetRuleEntityId",
                table: "Regions");

            migrationBuilder.DropForeignKey(
                name: "FK_VersionRanges_AppVersionEntity_MaxId",
                table: "VersionRanges");

            migrationBuilder.DropForeignKey(
                name: "FK_VersionRanges_AppVersionEntity_MinId",
                table: "VersionRanges");

            migrationBuilder.DropTable(
                name: "AppVersionEntity");

            migrationBuilder.RenameColumn(
                name: "FlagStormTargetRuleEntityId",
                table: "Regions",
                newName: "FlagStormTargetRuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Regions_FlagStormTargetRuleEntityId",
                table: "Regions",
                newName: "IX_Regions_FlagStormTargetRuleId");

            migrationBuilder.RenameColumn(
                name: "FlagStormTargetRuleEntityId",
                table: "OperatingSystems",
                newName: "FlagStormTargetRuleId");

            migrationBuilder.RenameIndex(
                name: "IX_OperatingSystems_FlagStormTargetRuleEntityId",
                table: "OperatingSystems",
                newName: "IX_OperatingSystems_FlagStormTargetRuleId");

            migrationBuilder.RenameColumn(
                name: "FlagStormTargetRuleEntityId",
                table: "Locales",
                newName: "FlagStormTargetRuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Locales_FlagStormTargetRuleEntityId",
                table: "Locales",
                newName: "IX_Locales_FlagStormTargetRuleId");

            migrationBuilder.RenameColumn(
                name: "FlagStormTargetRuleEntityId",
                table: "Environments",
                newName: "FlagStormTargetRuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Environments_FlagStormTargetRuleEntityId",
                table: "Environments",
                newName: "IX_Environments_FlagStormTargetRuleId");

            migrationBuilder.RenameColumn(
                name: "FlagStormTargetRuleEntityId",
                table: "DeviceTypes",
                newName: "FlagStormTargetRuleId");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceTypes_FlagStormTargetRuleEntityId",
                table: "DeviceTypes",
                newName: "IX_DeviceTypes_FlagStormTargetRuleId");

            migrationBuilder.RenameColumn(
                name: "FlagStormTargetRuleEntityId",
                table: "Browsers",
                newName: "FlagStormTargetRuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Browsers_FlagStormTargetRuleEntityId",
                table: "Browsers",
                newName: "IX_Browsers_FlagStormTargetRuleId");

            migrationBuilder.RenameColumn(
                name: "FlagStormTargetRuleEntityId",
                table: "AccountIds",
                newName: "FlagStormTargetRuleId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountIds_FlagStormTargetRuleEntityId",
                table: "AccountIds",
                newName: "IX_AccountIds_FlagStormTargetRuleId");

            migrationBuilder.CreateTable(
                name: "AppVersion",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppVersion", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountIds_TargetRules_FlagStormTargetRuleId",
                table: "AccountIds",
                column: "FlagStormTargetRuleId",
                principalTable: "TargetRules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Browsers_TargetRules_FlagStormTargetRuleId",
                table: "Browsers",
                column: "FlagStormTargetRuleId",
                principalTable: "TargetRules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceTypes_TargetRules_FlagStormTargetRuleId",
                table: "DeviceTypes",
                column: "FlagStormTargetRuleId",
                principalTable: "TargetRules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Environments_TargetRules_FlagStormTargetRuleId",
                table: "Environments",
                column: "FlagStormTargetRuleId",
                principalTable: "TargetRules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locales_TargetRules_FlagStormTargetRuleId",
                table: "Locales",
                column: "FlagStormTargetRuleId",
                principalTable: "TargetRules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatingSystems_TargetRules_FlagStormTargetRuleId",
                table: "OperatingSystems",
                column: "FlagStormTargetRuleId",
                principalTable: "TargetRules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_TargetRules_FlagStormTargetRuleId",
                table: "Regions",
                column: "FlagStormTargetRuleId",
                principalTable: "TargetRules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VersionRanges_AppVersion_MaxId",
                table: "VersionRanges",
                column: "MaxId",
                principalTable: "AppVersion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VersionRanges_AppVersion_MinId",
                table: "VersionRanges",
                column: "MinId",
                principalTable: "AppVersion",
                principalColumn: "Id");
        }
    }
}
