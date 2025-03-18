using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentHostel.DAL.Migrations
{
    /// <inheritdoc />
    public partial class hostel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apartments_owners_Owner_Id1",
                table: "apartments");

            migrationBuilder.DropTable(
                name: "owners");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropIndex(
                name: "IX_apartments_Owner_Id1",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "Owner_Id",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "Owner_Id1",
                table: "apartments");

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "apartments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "apartments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_apartments_OwnerId",
                table: "apartments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_apartments_StudentId",
                table: "apartments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_apartments_AspNetUsers_OwnerId",
                table: "apartments",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_apartments_AspNetUsers_StudentId",
                table: "apartments",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apartments_AspNetUsers_OwnerId",
                table: "apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_apartments_AspNetUsers_StudentId",
                table: "apartments");

            migrationBuilder.DropIndex(
                name: "IX_apartments_OwnerId",
                table: "apartments");

            migrationBuilder.DropIndex(
                name: "IX_apartments_StudentId",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "apartments");

            migrationBuilder.AddColumn<long>(
                name: "Owner_Id",
                table: "apartments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Owner_Id1",
                table: "apartments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    Owner_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_Phone = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.Owner_Id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apartment_Id = table.Column<int>(type: "int", nullable: false),
                    College = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Student_FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_Phone = table.Column<long>(type: "bigint", nullable: false),
                    Student_email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Student_Id);
                    table.ForeignKey(
                        name: "FK_students_apartments_Apartment_Id",
                        column: x => x.Apartment_Id,
                        principalTable: "apartments",
                        principalColumn: "Apartment_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_apartments_Owner_Id1",
                table: "apartments",
                column: "Owner_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_students_Apartment_Id",
                table: "students",
                column: "Apartment_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_apartments_owners_Owner_Id1",
                table: "apartments",
                column: "Owner_Id1",
                principalTable: "owners",
                principalColumn: "Owner_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
