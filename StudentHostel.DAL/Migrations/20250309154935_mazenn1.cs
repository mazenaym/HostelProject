using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentHostel.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mazenn1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_apartments_Apartment_Id",
                table: "comments");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_comments_StudentId",
                table: "comments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_AspNetUsers_StudentId",
                table: "comments",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_apartments_Apartment_Id",
                table: "comments",
                column: "Apartment_Id",
                principalTable: "apartments",
                principalColumn: "Apartment_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_AspNetUsers_StudentId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_apartments_Apartment_Id",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_StudentId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "comments");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_apartments_Apartment_Id",
                table: "comments",
                column: "Apartment_Id",
                principalTable: "apartments",
                principalColumn: "Apartment_Id");
        }
    }
}
