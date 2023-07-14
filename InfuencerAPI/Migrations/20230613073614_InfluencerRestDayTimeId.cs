using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfuencerAPI.Migrations
{
    public partial class InfluencerRestDayTimeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "InfluencerRestDay");

            migrationBuilder.AddColumn<Guid>(
                name: "TimeId",
                table: "InfluencerRestDay",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeId",
                table: "InfluencerRestDay");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "InfluencerRestDay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
