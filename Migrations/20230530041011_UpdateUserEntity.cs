using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotNetStudy.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "유저");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "유저",
                newName: "패스워드");

            migrationBuilder.RenameColumn(
                name: "loginId",
                table: "유저",
                newName: "로그인 아이디");

            migrationBuilder.AddPrimaryKey(
                name: "PK_유저",
                table: "유저",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_유저",
                table: "유저");

            migrationBuilder.RenameTable(
                name: "유저",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "패스워드",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "로그인 아이디",
                table: "Users",
                newName: "loginId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
