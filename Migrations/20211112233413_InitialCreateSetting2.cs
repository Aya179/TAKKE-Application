using Microsoft.EntityFrameworkCore.Migrations;

namespace Takke.Migrations
{
    public partial class InitialCreateSetting2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_settings",
                table: "settings",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_settings",
                table: "settings");
        }
    }
}
