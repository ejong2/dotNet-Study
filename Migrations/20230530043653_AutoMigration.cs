using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotNetStudy.Migrations
{
    /// <inheritdoc />
    public partial class AutoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "캐릭터",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    가슴파트 = table.Column<int>(name: "가슴 파트", type: "int", nullable: false),
                    얼굴파트 = table.Column<int>(name: "얼굴 파트", type: "int", nullable: false),
                    머리파트 = table.Column<int>(name: "머리 파트", type: "int", nullable: false),
                    다리파트 = table.Column<int>(name: "다리 파트", type: "int", nullable: false),
                    눈파트 = table.Column<int>(name: "눈 파트", type: "int", nullable: false),
                    손파트 = table.Column<int>(name: "손 파트", type: "int", nullable: false),
                    수염파트 = table.Column<int>(name: "수염 파트", type: "int", nullable: false),
                    성별 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    캐릭터소유유저 = table.Column<int>(name: "캐릭터 소유 유저", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_캐릭터", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "캐릭터");
        }
    }
}
