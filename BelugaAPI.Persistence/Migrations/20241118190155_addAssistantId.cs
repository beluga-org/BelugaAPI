using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BelugaAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addAssistantId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "content",
                table: "video",
                newName: "assistant_external_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "assistant_external_id",
                table: "video",
                newName: "content");
        }
    }
}
