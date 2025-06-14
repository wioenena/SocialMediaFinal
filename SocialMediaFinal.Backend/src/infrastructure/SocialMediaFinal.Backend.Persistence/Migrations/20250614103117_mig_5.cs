using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaFinal.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostEntity_Accounts_AuthorId",
                table: "PostEntity");

            migrationBuilder.DropIndex(
                name: "IX_PostEntity_AuthorId",
                table: "PostEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountEntityId",
                table: "PostEntity",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostEntity_AccountEntityId",
                table: "PostEntity",
                column: "AccountEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostEntity_Accounts_AccountEntityId",
                table: "PostEntity",
                column: "AccountEntityId",
                principalTable: "Accounts",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostEntity_Accounts_AccountEntityId",
                table: "PostEntity");

            migrationBuilder.DropIndex(
                name: "IX_PostEntity_AccountEntityId",
                table: "PostEntity");

            migrationBuilder.DropColumn(
                name: "AccountEntityId",
                table: "PostEntity");

            migrationBuilder.CreateIndex(
                name: "IX_PostEntity_AuthorId",
                table: "PostEntity",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostEntity_Accounts_AuthorId",
                table: "PostEntity",
                column: "AuthorId",
                principalTable: "Accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
