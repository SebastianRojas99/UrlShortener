using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLshorter.Migrations
{
    /// <inheritdoc />
    public partial class userId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MisURL_Users_UserId",
                table: "MisURL");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MisURL",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MisURL_Users_UserId",
                table: "MisURL",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MisURL_Users_UserId",
                table: "MisURL");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MisURL",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_MisURL_Users_UserId",
                table: "MisURL",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
