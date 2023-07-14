using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfuencerAPI.Migrations
{
    public partial class OrderTargetFilePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderTargets_Settings_TargetSettingId",
                table: "OrderTargets");

            migrationBuilder.DropIndex(
                name: "IX_OrderTargets_TargetSettingId",
                table: "OrderTargets");

            migrationBuilder.DropColumn(
                name: "TargetSettingId",
                table: "OrderTargets");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "OrderTargets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "OrderTargets");

            migrationBuilder.AddColumn<Guid>(
                name: "TargetSettingId",
                table: "OrderTargets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderTargets_TargetSettingId",
                table: "OrderTargets",
                column: "TargetSettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTargets_Settings_TargetSettingId",
                table: "OrderTargets",
                column: "TargetSettingId",
                principalTable: "Settings",
                principalColumn: "Id");
        }
    }
}
