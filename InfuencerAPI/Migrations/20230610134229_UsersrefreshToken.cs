using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfuencerAPI.Migrations
{
    public partial class UsersrefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "UsersLogin",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "UsersLogin");
        }
    }
}
