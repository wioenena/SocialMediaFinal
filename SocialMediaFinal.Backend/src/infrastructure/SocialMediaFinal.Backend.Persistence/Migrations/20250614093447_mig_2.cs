using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaFinal.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountEntityAccountEntity",
                columns: table => new
                {
                    FollowersId = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountEntityAccountEntity", x => new { x.FollowersId, x.FollowingId });
                    table.ForeignKey(
                        name: "FK_AccountEntityAccountEntity_Accounts_FollowersId",
                        column: x => x.FollowersId,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountEntityAccountEntity_Accounts_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Likes = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostEntity", x => x.id);
                    table.ForeignKey(
                        name: "FK_PostEntity_Accounts_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostCommentEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCommentEntity", x => x.id);
                    table.ForeignKey(
                        name: "FK_PostCommentEntity_PostEntity_PostId",
                        column: x => x.PostId,
                        principalTable: "PostEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountEntityAccountEntity_FollowingId",
                table: "AccountEntityAccountEntity",
                column: "FollowingId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentEntity_PostId",
                table: "PostCommentEntity",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostEntity_AuthorId",
                table: "PostEntity",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountEntityAccountEntity");

            migrationBuilder.DropTable(
                name: "PostCommentEntity");

            migrationBuilder.DropTable(
                name: "PostEntity");
        }
    }
}
