using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BelugaAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class moreCoreTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_video_user_userid",
                table: "video");

            migrationBuilder.DropIndex(
                name: "IX_video_userid",
                table: "video");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "video");

            migrationBuilder.CreateTable(
                name: "access_key",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    key = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_access_key", x => x.id);
                    table.ForeignKey(
                        name: "FK_access_key_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_video_user_id",
                table: "video",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_access_key_user_id",
                table: "access_key",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_video_user_user_id",
                table: "video",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_video_user_user_id",
                table: "video");

            migrationBuilder.DropTable(
                name: "access_key");

            migrationBuilder.DropIndex(
                name: "IX_video_user_id",
                table: "video");

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "video",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_video_userid",
                table: "video",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_video_user_userid",
                table: "video",
                column: "userid",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
