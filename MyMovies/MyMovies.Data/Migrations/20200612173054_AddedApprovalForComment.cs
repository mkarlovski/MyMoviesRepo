using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Data.Migrations
{
    public partial class AddedApprovalForComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "MovieComments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "MovieComments");
        }
    }
}
