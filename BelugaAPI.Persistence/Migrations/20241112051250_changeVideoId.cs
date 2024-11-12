using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BelugaAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeVideoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "video",
                newName: "original_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "original_name",
                table: "video",
                newName: "title");
        }
    }
}
