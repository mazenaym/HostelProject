using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentHostel.DAL.Migrations
{
    /// <inheritdoc />
    public partial class hostel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    Owner_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner_Phone = table.Column<long>(type: "bigint", nullable: false),
                    Owner_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_LName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.Owner_Id);
                });

            migrationBuilder.CreateTable(
                name: "apartments",
                columns: table => new
                {
                    Apartment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorNum = table.Column<int>(type: "int", nullable: false),
                    Num_Room = table.Column<int>(type: "int", nullable: false),
                    Num_Bed = table.Column<int>(type: "int", nullable: false),
                    Publisheddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRented = table.Column<bool>(type: "bit", nullable: false),
                    Owner_Id = table.Column<long>(type: "bigint", nullable: false),
                    Owner_Id1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apartments", x => x.Apartment_Id);
                    table.ForeignKey(
                        name: "FK_apartments_owners_Owner_Id1",
                        column: x => x.Owner_Id1,
                        principalTable: "owners",
                        principalColumn: "Owner_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Comment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apartment_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Comment_ID);
                    table.ForeignKey(
                        name: "FK_comments_apartments_Apartment_Id",
                        column: x => x.Apartment_Id,
                        principalTable: "apartments",
                        principalColumn: "Apartment_Id");
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_Phone = table.Column<long>(type: "bigint", nullable: false),
                    Student_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    College = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apartment_Id = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_comments_Apartment_Id",
                table: "comments",
                column: "Apartment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_students_Apartment_Id",
                table: "students",
                column: "Apartment_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "apartments");

            migrationBuilder.DropTable(
                name: "owners");
        }
    }
}
