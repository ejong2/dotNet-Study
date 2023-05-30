using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotNetStudy.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestUsers",
                table: "TestUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Avatars",
                table: "Avatars");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "유저");

            migrationBuilder.RenameTable(
                name: "TestUsers",
                newName: "테스트 테이블");

            migrationBuilder.RenameTable(
                name: "Avatars",
                newName: "캐릭터");

            migrationBuilder.AddPrimaryKey(
                name: "PK_유저",
                table: "유저",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_테스트 테이블",
                table: "테스트 테이블",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_캐릭터",
                table: "캐릭터",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_테스트 테이블",
                table: "테스트 테이블");

            migrationBuilder.DropPrimaryKey(
                name: "PK_캐릭터",
                table: "캐릭터");

            migrationBuilder.DropPrimaryKey(
                name: "PK_유저",
                table: "유저");

            migrationBuilder.RenameTable(
                name: "테스트 테이블",
                newName: "TestUsers");

            migrationBuilder.RenameTable(
                name: "캐릭터",
                newName: "Avatars");

            migrationBuilder.RenameTable(
                name: "유저",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestUsers",
                table: "TestUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avatars",
                table: "Avatars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
