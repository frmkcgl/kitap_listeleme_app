using Microsoft.EntityFrameworkCore.Migrations;

namespace kitap_listeleme_app.Migrations
{
    public partial class IsbnInsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Kitap",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Kitap");
        }
    }
}
