using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaFinal.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountEntityAccountEntity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_AccountEntityAccountEntity_FollowingId",
                table: "AccountEntityAccountEntity",
                column: "FollowingId");
        }
    }
}
