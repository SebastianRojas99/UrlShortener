using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLshorter.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MisURL",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Pass = table.Column<string>(type: "TEXT", nullable: false),
                    Rol = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MisURL_UserId",
                table: "MisURL",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MisURL_Users_UserId",
                table: "MisURL",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MisURL_Users_UserId",
                table: "MisURL");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_MisURL_UserId",
                table: "MisURL");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MisURL");
        }
    }
}
